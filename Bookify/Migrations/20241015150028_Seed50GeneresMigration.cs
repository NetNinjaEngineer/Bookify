using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Migrations
{
	/// <inheritdoc />
	public partial class Seed50GeneresMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
		   table: "Genres",
		   columns: new[] { "GenreName" },
		   values: new object[,]
		   {
				{ "Action" },
				{ "Biography" },
				{ "Self-Help" },
				{ "Health & Wellness" },
				{ "Cooking" },
				{ "Travel" },
				{ "Poetry" },
				{ "Children's" },
				{ "Graphic Novel" },
				{ "Classic" },
				{ "Cyberpunk" },
				{ "Crime" },
				{ "Non-Fiction" },
				{ "Anthology" },
				{ "Drama" },
				{ "Sports" },
				{ "Political" },
				{ "Religious" },
				{ "Inspirational" },
				{ "Chick Lit" },
				{ "Suspense" },
				{ "Family Saga" },
				{ "True Crime" },
				{ "Historical Romance" },
				{ "Space Opera" },
				{ "Post-Apocalyptic" },
				{ "Military Fiction" },
				{ "New Adult" },
				{ "Romantic Suspense" },
				{ "Fairy Tale" },
				{ "Superhero" },
				{ "Horror Comedy" },
				{ "Eco-Fiction" },
				{ "Slipstream" },
				{ "Surrealism" },
				{ "Absurdist" },
				{ "Bizarro Fiction" },
				{ "Interactive Fiction" },
				{ "Fantasy Romance" },
				{ "Cultural" },
				{ "Mythology" },
				{ "Historical Mystery" },
				{ "Alternative History" },
				{ "Comic" },
				{ "Romantic Comedy" },
				{ "Children's Poetry" },
				{ "Humor" },
				{ "Memoir" },
				{ "Classic Literature" },
				{ "Visionary Fiction" },
				{ "Science Fantasy" },
				{ "Spiritual" }
		   });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
			table: "Genres",
			keyColumn: "GenreName", // Adjust this if your key is different
			keyValues: new object[]
			{
				"Action", "Biography", "Self-Help", "Health & Wellness", "Cooking",
				"Travel", "Poetry", "Children's", "Graphic Novel", "Classic",
				"Cyberpunk", "Crime", "Non-Fiction", "Anthology", "Drama",
				"Sports", "Political", "Religious", "Inspirational", "Chick Lit",
				"Suspense", "Family Saga", "True Crime", "Historical Romance",
				"Space Opera", "Post-Apocalyptic", "Military Fiction", "New Adult",
				"Romantic Suspense", "Fairy Tale", "Superhero", "Horror Comedy",
				"Eco-Fiction", "Slipstream", "Surrealism", "Absurdist",
				"Bizarro Fiction", "Interactive Fiction", "Fantasy Romance",
				"Cultural", "Mythology", "Historical Mystery", "Alternative History",
				"Comic", "Romantic Comedy", "Children's Poetry", "Humor", "Memoir",
				"Classic Literature", "Visionary Fiction", "Science Fantasy", "Spiritual"
			});
		}
	}
}
