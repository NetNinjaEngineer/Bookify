using Bookify.Entities;
using System.Linq.Expressions;

namespace Bookify.Specifications;

public class BaseSpecification<TEntity> : IBaseSpecification<TEntity> where TEntity : BaseEntity
{
	public List<Expression<Func<TEntity, object>>> Includes { get; set; } = [];
	public Expression<Func<TEntity, bool>> Criteria { get; set; }

	// constructor for criteria

	public BaseSpecification() { }

	public BaseSpecification(Expression<Func<TEntity, bool>> criteria) => Criteria = criteria;

	protected void AddIncludes(Expression<Func<TEntity, object>>? includeExpression)
	{
		if (includeExpression is not null)
			Includes.Add(includeExpression);
	}

}
