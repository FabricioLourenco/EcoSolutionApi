using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Interface.Infra.Data;
using EcoSolution.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EcoSolution.Infra.Data.Data
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity, new()
    {
        protected EcoSolutionContext _context;

        public BaseRepository(EcoSolutionContext context)
        {
            _context = context;

        }

        public IQueryable<T> Query() => _context.Set<T>().AsQueryable();

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.Set<T>().Update(entity);
            });
        }

        public async Task RemoveAsync(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Remove(entity);
            });
        }

        public void RemoveById(long id)
        {
            var entity = new T { Id = id };
            _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

    }
}
