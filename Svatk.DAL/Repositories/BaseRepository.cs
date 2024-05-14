using Microsoft.EntityFrameworkCore;
using Svatk.Domain.Interfaces.Repository;

namespace Svatk.DAL.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new NullReferenceException("Entity is null");
        }

        await _dbContext.AddAsync(entity);

        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        if (entity == null)
        {
            throw new NullReferenceException("Entity is null");
        }

        _dbContext.Update(entity);

        return entity;
    }

    public void Remove(TEntity entity)
    {
        if (entity == null)
        {
            throw new NullReferenceException("Entity is null");
        }

        _dbContext.Remove(entity);
    }

    public async Task<int> SaveChangeAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}