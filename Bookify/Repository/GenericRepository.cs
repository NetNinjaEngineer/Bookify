using Bookify.Data;
using Bookify.Entities;
using Bookify.Repository.Contracts;
using Bookify.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Repository;

public class GenericRepository<TEntity>
	: IGenericRepository<TEntity> where TEntity : BaseEntity
{
	protected readonly ApplicationDbContext context;

	public GenericRepository(ApplicationDbContext context)
	{
		this.context = context;
	}

	public void Add(TEntity entity)
	{
		context.Add(entity);
		context.SaveChanges();
	}

	public async Task CommitAsync() => await context.SaveChangesAsync();

	public async Task<int> CountWithSpecificationAsync(IBaseSpecification<TEntity> specification)
		=> await SpecificationQueryEvaluator.BuildQuery(context.Set<TEntity>(), specification).CountAsync();

	public void Delete(TEntity entity)
	{
		context.Remove(entity);
		context.SaveChanges();
	}

	public async Task<TEntity?> ExistsAsync(int id) => await context.Set<TEntity>().FindAsync(id);

	public async Task<IEnumerable<TEntity>> GetAllAsync()
		=> await context.Set<TEntity>().ToListAsync();

	public async Task<IEnumerable<TEntity>> GetAllWithSpecificationAsync(IBaseSpecification<TEntity> specification)
		=> await SpecificationQueryEvaluator.BuildQuery(context.Set<TEntity>(), specification).ToListAsync();


	public async Task<TEntity?> GetByIdAsync(int id)
		=> await context.Set<TEntity>().FindAsync(id);

	public async Task<TEntity?> GetEntityBySpecificationAsync(IBaseSpecification<TEntity> specification)
		=> await SpecificationQueryEvaluator.BuildQuery(context.Set<TEntity>(), specification).FirstOrDefaultAsync();

	public void Update(TEntity entity)
	{
		context.Update(entity);
		context.SaveChanges();
	}
}
