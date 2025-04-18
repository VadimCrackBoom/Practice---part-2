using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILoggerManager _logger;
    private readonly IRepositoryManager _repository;

    public WeatherForecastController(ILoggerManager logger)
    {
        _logger = logger;
    }
    

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

    }
    
    public WeatherForecastController(IRepositoryManager repository)
    {
        _repository = repository;
    }

    [HttpGet("values")]
    public ActionResult<IEnumerable<string>> GetValues()
    {
        _repository.Company.AnyMethodFromCompanyRepository();
        _repository.Employees.AnyMethodFromEmployeeRepository();
        return new string[] { "value1", "value2" };
    }
}
    