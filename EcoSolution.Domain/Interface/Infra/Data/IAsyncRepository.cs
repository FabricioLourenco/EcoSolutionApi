using EcoSolution.Domain.Entities.Base;

namespace EcoSolution.Domain.Interface.Infra.Data
{
    public interface IAsyncRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> Query();

        Task SaveChangesAsync();

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);

    }
}
