using Bookify.Data;
using Bookify.Entities;
using Bookify.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Repository;

public class GenericRepository<TEntity>(
    ApplicationDbContext context) : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    public void Add(TEntity entity)
    {
        context.Add(entity);
        context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        context.Remove(entity);
        context.SaveChanges();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await context.Set<TEntity>().ToListAsync();

    public async Task<TEntity> GetByIdAsync(int id)
        => await context.Set<TEntity>().FindAsync(id);

    public void Update(TEntity entity)
    {
        context.Update(entity);
        context.SaveChanges();
    }
}
