using Contracts;
using Entities;
using Entities.Models;

namespace Repository;

public class CompanyRepository: RepositoryBase<Company>, ICompanyRepository
{
    private ICompanyRepository _companyRepositoryImplementation;

    public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
        
    }
    
    public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
    FindAll(trackChanges)
        .OrderBy(c => c.Name)
    .ToList();

    public void AnyMethodFromCompanyRepository()
    {
        Console.WriteLine("AnyMethodFromCompanyRepository");
    }
}