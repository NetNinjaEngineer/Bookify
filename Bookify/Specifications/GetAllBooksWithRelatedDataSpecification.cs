using Bookify.Entities;

namespace Bookify.Specifications;

public class GetAllBooksWithRelatedDataSpecification : BaseSpecification<Book>
{
	public GetAllBooksWithRelatedDataSpecification()
	{
		AddIncludes(x => x.Tags);
		AddIncludes(x => x.Author!);
		AddIncludes(x => x.BookTags);
		AddIncludes(x => x.Publisher!);
		AddIncludes(x => x.Genre!);
		AddIncludes(x => x.Reviews!);

	}

	public GetAllBooksWithRelatedDataSpecification(int skip, int take)
	{
		AddIncludes(x => x.Tags);
		AddIncludes(x => x.Author!);
		AddIncludes(x => x.BookTags);
		AddIncludes(x => x.Publisher!);
		AddIncludes(x => x.Genre!);
		AddIncludes(x => x.Reviews!);

		IsPagingEnabled = true;

		AddPagination(skip, take);

	}

	public GetAllBooksWithRelatedDataSpecification(int bookId) : base(x => x.Id == bookId)
	{
		AddIncludes(x => x.Tags);
		AddIncludes(x => x.Author!);
		AddIncludes(x => x.BookTags);
		AddIncludes(x => x.Publisher!);
		AddIncludes(x => x.Genre!);
		AddIncludes(x => x.Reviews!);
	}
}
