using Contracts;
using Entities;
using Entities.Models;

namespace Repository;

public class EmployeeRepository: RepositoryBase<Employee>, IEmployeeRepository
{
    private IEmployeeRepository _employeeRepositoryImplementation;

    public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
        
    }

    public void AnyMethodFromEmployeeRepository()
    {
        _employeeRepositoryImplementation.AnyMethodFromEmployeeRepository();
    }
}