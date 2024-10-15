using Bookify.Entities;

namespace Bookify.Specifications;

public class GetExistedReviewWithUserAndProductSpecification : BaseSpecification<Review>
{
	public GetExistedReviewWithUserAndProductSpecification(string userId, int bookId) : base(r => r.UserId == userId && r.BookId == bookId && r.BookId == bookId)
	{
		AddIncludes(r => r.User);
		AddIncludes(r => r.Book);
	}
}
