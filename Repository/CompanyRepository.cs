using Contracts;
using Entities;
using Entities.DataTransferObjects;
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
    
    public Company GetCompany(Guid companyId, bool trackChanges) =>
    FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();
    
    public void CreateCompany(Company company) => Create(company);
    
    public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
    FindByCondition(x => ids.Contains(x.Id), trackChanges).ToList();
}