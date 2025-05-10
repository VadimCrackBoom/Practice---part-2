using System.Linq.Expressions;

namespace Contracts;


public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate, bool trackChanges);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}