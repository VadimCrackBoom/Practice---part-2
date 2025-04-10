using Entities;
using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public RepositoryManager(
            RepositoryContext repositoryContext,
            ICompanyRepository companyRepository,
            IEmployeeRepository employeeRepository)
        {
            _repositoryContext = repositoryContext;
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
        }

        public ICompanyRepository Company => _companyRepository;

        public IEmployeeRepository Employee => _employeeRepository;

        public void Save() => _repositoryContext.SaveChanges();

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}