using Bookify.Entities;

namespace Bookify.Specifications;

public class GetAllBooksWithGenresAndAuthorsSpecification : BaseSpecification<Book>
{
	public GetAllBooksWithGenresAndAuthorsSpecification(string searchTerm)
		: base(
			x => string.IsNullOrEmpty(searchTerm) ||
				 (x.Title!.ToLower().Contains(searchTerm) ||
				  (x.Author!.FirstName + " " + x.Author.LastName).Contains(searchTerm) ||
				  x.Genre!.GenreName!.Contains(searchTerm)))
	{
		AddIncludes(x => x.Author!);
		AddIncludes(x => x.Genre!);
	}
}