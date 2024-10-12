﻿using Bookify.Entities;

namespace Bookify.Data.DataSeed;

public static class BooksSeed
{
	public static List<Book> GetBooks()
	{
		List<Book> books =
		[
			new() { StockQuantity = 100, Title = "C# in Depth", Description = "A comprehensive guide to C# and its features.", Price = 49.99m, ImageName = "C# in Depth book.jpg", ISBN = "9781617294532", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 900, Lessons = 40 },
			new() { StockQuantity = 100, Title = "Pro C# 9", Description = "Professional programming in C# 9 with .NET 5.", Price = 59.99m, ImageName = "Pro C# 9.jpeg", ISBN = "9781484260190", EditionLanguage = EditionLanguage.English, BookFormat = "Hardcover", Pages = 1100, Lessons = 50 },
			new() { StockQuantity = 100, Title = "C# 9.0 in a Nutshell", Description = "The essential guide to C# 9.0 and .NET 5.", Price = 39.99m, ImageName = "C# 9.0 in a Nutshell.jpeg", ISBN = "9781098100964", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 1040, Lessons = 45 },
			new() { StockQuantity = 100, Title = "CLR via C#", Description = "Understanding the common language runtime.", Price = 44.99m, ImageName = "CLR via C#.jpeg", ISBN = "9780735667457", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 816, Lessons = 35 },
			new() { StockQuantity = 100, Title = "Head First C#", Description = "A brain-friendly guide to learning C#.", Price = 34.99m, ImageName = "Head First C#.jpeg", ISBN = "9781491976708", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 800, Lessons = 30 },
			new() { StockQuantity = 100, Title = "Effective C#", Description = "50 Specific Ways to Improve Your C#.", Price = 29.99m, ImageName = "Effective C#.jpeg", ISBN = "9780135159941", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 320, Lessons = 20 },
			new() { StockQuantity = 100, Title = "C# 7.0 in a Nutshell", Description = "The definitive reference for C# 7.0.", Price = 39.99m, ImageName = "C# 7.0 in a Nutshell.png", ISBN = "9781491987650", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 1080, Lessons = 48 },
			new() { StockQuantity = 100, Title = "C# Cookbook", Description = "Solutions and examples for C# programmers.", Price = 44.99m, ImageName = "C# Cookbook.jpeg", ISBN = "9781492057632", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 850, Lessons = 42 },
			new() { StockQuantity = 100, Title = "Beginning C# and .NET", Description = "An introduction to C# and the .NET framework.", Price = 29.99m, ImageName = "Beginning C# and .NET.jpeg", ISBN = "9781484256919", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 650, Lessons = 28 },
			new() { StockQuantity = 100, Title = "C# Programming Yellow Book", Description = "A free introduction to C# programming.", Price = 0.00m, ImageName = "C# Programming Yellow Book.jpeg", ISBN = "N/A", EditionLanguage = EditionLanguage.English, BookFormat = "PDF", Pages = 250, Lessons = 15 },
			new() { StockQuantity = 100, Title = "Programming C# 8.0", Description = "A comprehensive guide to C# 8.0 programming.", Price = 49.99m, ImageName = "Programming C# 8.0.jpeg", ISBN = "9781492056819", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 1200, Lessons = 52 },
			new() { StockQuantity = 100, Title = "C# and .NET Core Test-Driven Development", Description = "Build better software by applying TDD with C#.", Price = 39.99m, ImageName = "C# and .NET Core Test-Driven Development.jpeg", ISBN = "9781788475602", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 400, Lessons = 18 },
			new() { StockQuantity = 100, Title = "C# Data Structures and Algorithms", Description = "Master the fundamentals of data structures and algorithms in C#.", Price = 44.99m, ImageName = "C# Data Structures and Algorithms.jpeg", ISBN = "9781788622044", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 500, Lessons = 22 },
			new() { StockQuantity = 100, Title = "C# for Beginners", Description = "Learn C# programming from scratch.", Price = 24.99m, ImageName = "C# for Beginners.png", ISBN = "9781838558364", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 320, Lessons = 18 },
			new() { StockQuantity = 100, Title = "C# Game Programming", Description = "Create games using C# and Unity.", Price = 39.99m, ImageName = "C# Game Programming.jpeg", ISBN = "9781471044653", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 620, Lessons = 26 },
			new() { StockQuantity = 100, Title = "ASP.NET Core in Action", Description = "Build web applications using ASP.NET Core.", Price = 54.99m, ImageName = "ASP.NET Core in Action.jpeg", ISBN = "9781617294617", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 550, Lessons = 24 },
			new() { StockQuantity = 100, Title = "C# 8.0 for Programmers", Description = "An introduction to C# 8.0 programming.", Price = 39.99m, ImageName = "C# 8.0 for Programmers.jpeg", ISBN = "9780135221495", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 950, Lessons = 42 },
			new() { StockQuantity = 100, Title = "Advanced C#", Description = "Deep dive into advanced C# programming techniques.", Price = 49.99m, ImageName = "Advanced C#.jpeg", ISBN = "9780134997835", EditionLanguage = EditionLanguage.English, BookFormat = "Hardcover", Pages = 880, Lessons = 38 },
			new() { StockQuantity = 100, Title = "C# 8.0 Unleashed", Description = "A comprehensive guide to C# 8.0.", Price = 59.99m, ImageName = "C# 8.0 Unleashed.jpeg", ISBN = "9780672337152", EditionLanguage = EditionLanguage.English, BookFormat = "Hardcover", Pages = 1000, Lessons = 44 },
			new() { StockQuantity = 100, Title = "Learning C# Programming", Description = "An introduction to C# programming concepts.", Price = 34.99m, ImageName = "Learning C# Programming.png", ISBN = "9781484248570", EditionLanguage = EditionLanguage.English, BookFormat = "Paperback", Pages = 550, Lessons = 25 }
		];


		return books;
	}
}