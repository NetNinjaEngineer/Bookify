using Bookify.Entities;

namespace Bookify.Data.DataSeed;

public static class AuthorsSeed
{
    public static List<Author> GetAuthors()
    {
        List<Author> authors =
        [
            new() { FirstName = "Jon", LastName = "Skeet" },
            new() { FirstName = "Anders", LastName = "Hejlsberg" },
            new() { FirstName = "David", LastName = "K. A. M." },
            new() { FirstName = "Mark", LastName = "Michaelis" },
            new() { FirstName = "Bill", LastName = "Wagner" },
            new() { FirstName = "Scott", LastName = "Allen" },
            new() { FirstName = "Ben", LastName = "Hall" },
            new() { FirstName = "Megan", LastName = "Murray" },
            new() { FirstName = "John", LastName = "Sharp" },
            new() { FirstName = "Richard", LastName = "Banks" },
            new() { FirstName = "Chris", LastName = "Sells" },
            new() { FirstName = "Rob", LastName = "Miles" },
            new() { FirstName = "Sara", LastName = "Chipps" },
            new() { FirstName = "David", LastName = "Fowler" },
            new() { FirstName = "Michael", LastName = "P. H. J." },
            new() { FirstName = "Kathy", LastName = "Sierra" },
            new() { FirstName = "Jesse", LastName = "Liberty" },
            new() { FirstName = "M. J.", LastName = "P. G." },
            new() { FirstName = "Rico", LastName = "Mariani" },
            new() { FirstName = "Jeff", LastName = "Prosise" }
        ];
        return authors;
    }
}
