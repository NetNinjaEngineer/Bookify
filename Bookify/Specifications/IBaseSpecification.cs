using Bookify.Entities;
using System.Linq.Expressions;

namespace Bookify.Specifications;

public interface IBaseSpecification<TEntity> where TEntity : BaseEntity
{
	public List<Expression<Func<TEntity, object>>> Includes { get; set; }

	public Expression<Func<TEntity, bool>> Criteria { get; set; }

}
