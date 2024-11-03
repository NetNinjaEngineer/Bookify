using Bookify.Entities;
using System.Linq.Expressions;

namespace Bookify.Specifications;

public class BaseSpecification<TEntity> : IBaseSpecification<TEntity> where TEntity : BaseEntity
{
	public List<Expression<Func<TEntity, object>>> Includes { get; set; } = [];
	public Expression<Func<TEntity, bool>> Criteria { get; set; }
	public bool IsPagingEnabled { get; set; } = false;
	public int Skip { get; set; }
	public int Take { get; set; }

	// constructor for get all
	public BaseSpecification() { }


	// constructor for criteria
	public BaseSpecification(Expression<Func<TEntity, bool>> criteria) => Criteria = criteria;

	protected void AddIncludes(Expression<Func<TEntity, object>>? includeExpression)
	{
		if (includeExpression is not null)
			Includes.Add(includeExpression);
	}

	protected void AddPagination(int skip, int take)
	{
		IsPagingEnabled = true;
		Skip = skip;
		Take = take;
	}

}
