using CapitalPlacementTask.Models;
using System.Linq.Expressions;
namespace CapitalPlacementTask.IRepositories
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<T> GetById(Guid id);

        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<T> GetLastOrDefault(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetAll();

        Task<int> GetCount();

        Task<List<T>> GetPagedAll(int pagenumber, int pagesize);

        Task<Guid> GetMaxId();

        Task<List<T>> GetUsingConditions(Expression<Func<T, bool>> predicate);

        Task<int> GetCountUsingConditions(Expression<Func<T, bool>> predicate);

        Task<T> Insert(T model);

        Task<T> Update(T entity);

        Task Delete(T entity);
    }
}
