namespace Contracts;

public interface IRepositoryManager
{
    ICompanyRepository Company { get; }
    IEmployeeRepository Employees { get; }
    Task SaveAsync();
}