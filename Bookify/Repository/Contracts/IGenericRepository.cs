using Bookify.Entities;
using Bookify.Specifications;

namespace Bookify.Repository.Contracts;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
	void Add(TEntity entity);

	void Update(TEntity entity);

	void Delete(TEntity entity);

	Task<IEnumerable<TEntity>> GetAllAsync();

	Task<IEnumerable<TEntity>> GetAllWithSpecificationAsync(IBaseSpecification<TEntity> specification);

	Task<TEntity?> GetByIdAsync(int id);

	Task<TEntity?> GetEntityBySpecificationAsync(IBaseSpecification<TEntity> specification);

	Task CommitAsync();

	Task<TEntity?> ExistsAsync(int id);

	Task<int> CountWithSpecificationAsync(IBaseSpecification<TEntity> specification);

}
