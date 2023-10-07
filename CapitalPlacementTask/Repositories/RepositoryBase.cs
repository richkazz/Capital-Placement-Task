using CapitalPlacementTask.Data;
using CapitalPlacementTask.IRepositories;
using CapitalPlacementTask.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CapitalPlacementTask.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly CapitalPlacementTaskDbContext _dbContext;

        public RepositoryBase(CapitalPlacementTaskDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetLastOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().OrderByDescending(x => x.Id).FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetPagedAll(int pagenumber, int pagesize)
        {
            return await _dbContext.Set<T>()
                .Skip((pagenumber - 1) * pagesize).Take(pagesize)
                .ToListAsync();
        }

        public async Task<Guid> GetMaxId()
        {
            return await _dbContext.Set<T>().MaxAsync(p => p.Id);
        }

        public async Task<int> GetCount()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<List<T>> GetUsingConditions(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> GetCountUsingConditions(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).CountAsync();
        }

        public async Task<T> Insert(T model)
        {
            _dbContext.Set<T>().Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
