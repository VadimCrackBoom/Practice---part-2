using Entities.Models;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        void AnyMethodFromEmployeeRepository();

        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);

        Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
    }
}