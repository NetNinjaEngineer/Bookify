using Bookify.Entities;

namespace Bookify.Specifications;

public class GetAllBooksWithSpecifiedGenreSpecification : BaseSpecification<Book>
{
	public GetAllBooksWithSpecifiedGenreSpecification()
	{
		AddIncludes(b => b.Genre);
	}

}
