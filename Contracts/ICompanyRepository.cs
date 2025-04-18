using Entities.Models;

namespace Contracts;

public interface ICompanyRepository
{
    void AnyMethodFromCompanyRepository();
    
    IEnumerable<Company> GetAllCompanies(bool trackChanges);
}