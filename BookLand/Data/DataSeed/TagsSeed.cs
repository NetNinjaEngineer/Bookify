using Bookify.Entities;

namespace Bookify.Data.DataSeed;

public static class TagsSeed
{
	public static List<Tag> LoadTags()
	{
		var tags = new List<Tag>
		{
			new() { TagName = "Programming" },
			new() { TagName = "C#" },
			new() { TagName = "Software Development" },
			new() { TagName = "Data Structures" },
			new() { TagName = "Algorithms" },
			new() { TagName = "Game Development" },
			new() { TagName = "Test-Driven Development" },
			new() { TagName = "Web Development" },
			new() { TagName = "Advanced Programming" },
			new() { TagName = "Beginner Programming" },
			new() { TagName = "ASP.NET Core" },
			new() { TagName = "Unity" }
		};

		return tags;

	}
}
