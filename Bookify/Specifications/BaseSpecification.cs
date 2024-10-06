using Bookify.Entities;
using System.Linq.Expressions;

namespace Bookify.Specifications;

public class BaseSpecification<TEntity> : IBaseSpecification<TEntity> where TEntity : BaseEntity
{
    public List<Expression<Func<TEntity, object>>> Includes { get; set; } = [];

    protected void AddIncludes(List<Expression<Func<TEntity, object>>> includeExpressions)
        => Includes = includeExpressions;

}
