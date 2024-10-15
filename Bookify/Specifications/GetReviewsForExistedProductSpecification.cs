using Bookify.Entities;

namespace Bookify.Specifications;

public class GetReviewsForExistedProductSpecification : BaseSpecification<Review>
{
	public GetReviewsForExistedProductSpecification(int bookId) : base(r => r.BookId == bookId)
	{
		AddIncludes(x => x.Book);
		AddIncludes(x => x.User);
	}
}
