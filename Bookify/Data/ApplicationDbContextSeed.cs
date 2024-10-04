using Bookify.Entities;

namespace Bookify.Data;

public static class ApplicationDbContextSeed
{
    public static async Task SeedDatabaseAsync(this ApplicationDbContext dbContext)
    {
        if (!dbContext.Genres.Any())
        {
            var genres = new List<Genre>
            {
                new() { GenreName = "Science Fiction"},
                new() { GenreName = "Fantasy"},
                new() { GenreName = "Mystery"},
                new() { GenreName = "Romance"},
                new() { GenreName = "Horror"},
                new() { GenreName = "Thriller"},
                new() { GenreName = "Historical Fiction"},
                new() { GenreName = "Literary Fiction"},
                new() { GenreName = "Adventure"},
                new() { GenreName = "Dystopian"},
                new() { GenreName = "Young Adult (YA)"},
                new() { GenreName = "Urban Fantasy"},
                new() { GenreName = "Paranormal"},
                new() { GenreName = "Steampunk"},
                new() { GenreName = "Magical Realism"}
            };

            await dbContext.Genres.AddRangeAsync(genres);
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Books.Any())
        {
            List<Book> books =
            [
                new() { Title = "C# in Depth", Description = "A comprehensive guide to C# and its features.", Price = 49.99m },
                new() { Title = "Pro C# 9", Description = "Professional programming in C# 9 with .NET 5.", Price = 59.99m },
                new() { Title = "C# 9.0 in a Nutshell", Description = "The essential guide to C# 9.0 and .NET 5.", Price = 39.99m },
                new() { Title = "CLR via C#", Description = "Understanding the common language runtime.", Price = 44.99m },
                new() { Title = "Head First C#", Description = "A brain-friendly guide to learning C#.", Price = 34.99m },
                new() { Title = "Effective C#", Description = "50 Specific Ways to Improve Your C#.", Price = 29.99m },
                new() { Title = "C# 7.0 in a Nutshell", Description = "The definitive reference for C# 7.0.", Price = 39.99m },
                new() { Title = "C# Cookbook", Description = "Solutions and examples for C# programmers.", Price = 44.99m },
                new() { Title = "Beginning C# and .NET", Description = "An introduction to C# and the .NET framework.", Price = 29.99m },
                new() { Title = "C# Programming Yellow Book", Description = "A free introduction to C# programming.", Price = 0.00m },
                new() { Title = "Programming C# 8.0", Description = "A comprehensive guide to C# 8.0 programming.", Price = 49.99m },
                new() { Title = "C# and .NET Core Test-Driven Development", Description = "Build better software by applying TDD with C#.", Price = 39.99m },
                new() { Title = "C# Data Structures and Algorithms", Description = "Master the fundamentals of data structures and algorithms in C#.", Price = 44.99m },
                new() { Title = "C# for Beginners", Description = "Learn C# programming from scratch.", Price = 24.99m },
                new() { Title = "C# Game Programming", Description = "Create games using C# and Unity.", Price = 39.99m },
                new() { Title = "ASP.NET Core in Action", Description = "Build web applications using ASP.NET Core.", Price = 54.99m },
                new() { Title = "C# 8.0 for Programmers", Description = "An introduction to C# 8.0 programming.", Price = 39.99m },
                new() { Title = "Advanced C#", Description = "Deep dive into advanced C# programming techniques.", Price = 49.99m },
                new() { Title = "C# 8.0 Unleashed", Description = "A comprehensive guide to C# 8.0.", Price = 59.99m },
                new() { Title = "Learning C# Programming", Description = "An introduction to C# programming concepts.", Price = 34.99m }
            ];
            await dbContext.Books.AddRangeAsync(books);
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Authors.Any())
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

            await dbContext.Authors.AddRangeAsync(authors);
            await dbContext.SaveChangesAsync();
        }
    }
}
