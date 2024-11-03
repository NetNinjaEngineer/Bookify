using Bookify.Entities;

namespace Bookify.Data.DataSeed;

public static class BookTagsSeed
{
    public static List<BookTag> LoadBookTags()
    {
        List<BookTag> bookTags =
        [
            // C# in Depth (BookId = 1)
            new BookTag { BookId = 1, TagId = 1 }, // Programming
            new BookTag { BookId = 1, TagId = 2 }, // C#
            new BookTag { BookId = 1, TagId = 3 }, // Advanced

            // Pro C# 9 (BookId = 2)
            new BookTag { BookId = 2, TagId = 1 }, // Programming
            new BookTag { BookId = 2, TagId = 2 }, // C#
            new BookTag { BookId = 2, TagId = 3 }, // Advanced

            // C# 9.0 in a Nutshell (BookId = 3)
            new BookTag { BookId = 3, TagId = 1 }, // Programming
            new BookTag { BookId = 3, TagId = 2 }, // C#
            new BookTag { BookId = 3, TagId = 4 }, // Reference

            // CLR via C# (BookId = 4)
            new BookTag { BookId = 4, TagId = 1 }, // Programming
            new BookTag { BookId = 4, TagId = 5 }, // Runtime

            // Head First C# (BookId = 5)
            new BookTag { BookId = 5, TagId = 1 }, // Programming
            new BookTag { BookId = 5, TagId = 6 }, // Beginner

            // Effective C# (BookId = 6)
            new BookTag { BookId = 6, TagId = 1 }, // Programming
            new BookTag { BookId = 6, TagId = 7 }, // Best Practices

            // C# 7.0 in a Nutshell (BookId = 7)
            new BookTag { BookId = 7, TagId = 1 }, // Programming
            new BookTag { BookId = 7, TagId = 2 }, // C#
            new BookTag { BookId = 7, TagId = 4 }, // Reference

            // C# Cookbook (BookId = 8)
            new BookTag { BookId = 8, TagId = 1 }, // Programming
            new BookTag { BookId = 8, TagId = 2 }, // C#
            new BookTag { BookId = 8, TagId = 4 }, // Reference

            // Beginning C# and .NET (BookId = 9)
            new BookTag { BookId = 9, TagId = 1 }, // Programming
            new BookTag { BookId = 9, TagId = 6 }, // Beginner
            new BookTag { BookId = 9, TagId = 8 }, // .NET

            // C# Programming Yellow Book (BookId = 10)
            new BookTag { BookId = 10, TagId = 1 }, // Programming
            new BookTag { BookId = 10, TagId = 6 }, // Beginner

            // Programming C# 8.0 (BookId = 11)
            new BookTag { BookId = 11, TagId = 1 }, // Programming
            new BookTag { BookId = 11, TagId = 2 }, // C#
            new BookTag { BookId = 11, TagId = 3 }, // Advanced

            // C# and .NET Core Test-Driven Development (BookId = 12)
            new BookTag { BookId = 12, TagId = 1 }, // Programming
            new BookTag { BookId = 12, TagId = 9 }, // Test-Driven Development
            new BookTag { BookId = 12, TagId = 8 }, // .NET

            // C# Data Structures and Algorithms (BookId = 13)
            new BookTag { BookId = 13, TagId = 1 }, // Programming
            new BookTag { BookId = 13, TagId = 10 }, // Data Structures
            new BookTag { BookId = 13, TagId = 11 }, // Algorithms

            // C# for Beginners (BookId = 14)
            new BookTag { BookId = 14, TagId = 1 }, // Programming
            new BookTag { BookId = 14, TagId = 6 }, // Beginner

            // C# Game Programming (BookId = 15)
            new BookTag { BookId = 15, TagId = 1 }, // Programming
            new BookTag { BookId = 15, TagId = 12 }, // Game Development

            // ASP.NET Core in Action (BookId = 16)
            new BookTag { BookId = 16, TagId = 1 }, // Programming
            new BookTag { BookId = 16, TagId = 8 }, // .NET

            // C# 8.0 for Programmers (BookId = 17)
            new BookTag { BookId = 17, TagId = 1 }, // Programming
            new BookTag { BookId = 17, TagId = 2 }, // C#
            new BookTag { BookId = 17, TagId = 3 }, // Advanced

            // Advanced C# (BookId = 18)
            new BookTag { BookId = 18, TagId = 1 }, // Programming
            new BookTag { BookId = 18, TagId = 3 }, // Advanced

            // C# 8.0 Unleashed (BookId = 19)
            new BookTag { BookId = 19, TagId = 1 }, // Programming
            new BookTag { BookId = 19, TagId = 2 }, // C#
            new BookTag { BookId = 19, TagId = 3 }, // Advanced

            // Learning C# Programming (BookId = 20)
            new BookTag { BookId = 20, TagId = 1 }, // Programming
            new BookTag { BookId = 20, TagId = 6 }, // Beginner
        ];

        return bookTags;
    }
}
