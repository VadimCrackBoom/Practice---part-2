using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers;

[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController : Controller
{
    private readonly IRepositoryManager _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public EmployeesController(IRepositoryManager repository, ILogger<EmployeesController> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeesforCompany(Guid companyId, Guid id)
    {
        var company = _repository.Company.GetCompany(companyId, trackChanges: false);
        if (company == null)
        {
            _logger.LogInformation($"Company with id: {companyId} does not exist in the database.");
            return NotFound();
        }
        
        var employeeDb = _repository.Employees.GetEmployee(companyId, id, trackChanges: false);
        if (employeeDb == null)
        {
            _logger.LogInformation($"Employee with id: {id} does not exist in the database.");
            return NotFound();
        }
        var employee = _mapper.Map<EmployeeDto>(employeeDb);
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult CreateEmployeeForCompany(Guid companyId,
        [FromBody] EmployeeForCreationDto employee)
    {
        if (employee == null)
        {
            _logger.LogError("EmployeeForCreationDto object sent from client is null.");
            return BadRequest();
        }
        var company = _repository.Company.GetCompany(companyId, trackChanges: false);
        if (company == null)
        {
            _logger.LogInformation($"Company with id: {companyId} does not exist in the database.");
            return NotFound();
        }
        var employeeEntity = _mapper.Map<Employee>(employee);
        _repository.Employees.CreateEmployeeForCompany(companyId, employeeEntity);
        _repository.Save();
        var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
        return CreatedAtRoute("GetEmployeeForCompany", new
        {
            companyId, id = employeeToReturn.Id
        }, employeeToReturn);
    }
}