namespace Svatk.Domain.Interfaces.Repository;

public interface IBaseRepository<TEntity>
{
    IQueryable<TEntity> GetAll();
    
    Task<TEntity> CreateAsync(TEntity entity);
    
    TEntity Update(TEntity entity);
    
    void Remove(TEntity entity);
    
    Task<int> SaveChangeAsync();
}