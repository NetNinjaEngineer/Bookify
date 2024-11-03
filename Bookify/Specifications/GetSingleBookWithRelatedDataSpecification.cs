using Bookify.Entities;

namespace Bookify.Specifications;

public class GetSingleBookWithRelatedDataSpecification : BaseSpecification<Book>
{
	public GetSingleBookWithRelatedDataSpecification(int bookId) : base(x => x.Id == bookId)
	{
		AddIncludes(x => x.Reviews);
	}
}
