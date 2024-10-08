﻿using Bookify.Entities;

namespace Bookify.Data.DataSeed;

public static class BooksSeed
{
    public static List<Book> GetBooks()
    {
        List<Book> books =
        [
            new() { Title = "C# in Depth", Description = "A comprehensive guide to C# and its features.", Price = 49.99m, ImageName = "C# in Depth book.jpg" },
            new() { Title = "Pro C# 9", Description = "Professional programming in C# 9 with .NET 5.", Price = 59.99m, ImageName = "Pro C# 9.jpeg" },
            new() { Title = "C# 9.0 in a Nutshell", Description = "The essential guide to C# 9.0 and .NET 5.", Price = 39.99m, ImageName = "C# 9.0 in a Nutshell.jpeg" },
            new() { Title = "CLR via C#", Description = "Understanding the common language runtime.", Price = 44.99m, ImageName = "CLR via C#.jpeg" },
            new() { Title = "Head First C#", Description = "A brain-friendly guide to learning C#.", Price = 34.99m, ImageName = "Head First C#.jpeg" },
            new() { Title = "Effective C#", Description = "50 Specific Ways to Improve Your C#.", Price = 29.99m, ImageName = "Effective C#.jpeg" },
            new() { Title = "C# 7.0 in a Nutshell", Description = "The definitive reference for C# 7.0.", Price = 39.99m, ImageName = "C# 7.0 in a Nutshell.png" },
            new() { Title = "C# Cookbook", Description = "Solutions and examples for C# programmers.", Price = 44.99m, ImageName = "C# Cookbook.jpeg" },
            new() { Title = "Beginning C# and .NET", Description = "An introduction to C# and the .NET framework.", Price = 29.99m, ImageName = "Beginning C# and .NET.jpeg" },
            new() { Title = "C# Programming Yellow Book", Description = "A free introduction to C# programming.", Price = 0.00m, ImageName = "C# Programming Yellow Book.jpeg" },
            new() { Title = "Programming C# 8.0", Description = "A comprehensive guide to C# 8.0 programming.", Price = 49.99m, ImageName = "Programming C# 8.0.jpeg" },
            new() { Title = "C# and .NET Core Test-Driven Development", Description = "Build better software by applying TDD with C#.", Price = 39.99m, ImageName = "C# and .NET Core Test-Driven Development.jpeg" },
            new() { Title = "C# Data Structures and Algorithms", Description = "Master the fundamentals of data structures and algorithms in C#.", Price = 44.99m, ImageName = "C# Data Structures and Algorithms.jpeg" },
            new() { Title = "C# for Beginners", Description = "Learn C# programming from scratch.", Price = 24.99m, ImageName = "C# for Beginners.png" },
            new() { Title = "C# Game Programming", Description = "Create games using C# and Unity.", Price = 39.99m, ImageName = "C# Game Programming.jpeg" },
            new() { Title = "ASP.NET Core in Action", Description = "Build web applications using ASP.NET Core.", Price = 54.99m, ImageName = "ASP.NET Core in Action.jpeg" },
            new() { Title = "C# 8.0 for Programmers", Description = "An introduction to C# 8.0 programming.", Price = 39.99m, ImageName = "C# 8.0 for Programmers.jpeg" },
            new() { Title = "Advanced C#", Description = "Deep dive into advanced C# programming techniques.", Price = 49.99m, ImageName = "Advanced C#.jpeg" },
            new() { Title = "C# 8.0 Unleashed", Description = "A comprehensive guide to C# 8.0.", Price = 59.99m, ImageName = "C# 8.0 Unleashed.jpeg" },
            new() { Title = "Learning C# Programming", Description = "An introduction to C# programming concepts.", Price = 34.99m, ImageName = "Learning C# Programming.png" }
        ];

        return books;
    }
}