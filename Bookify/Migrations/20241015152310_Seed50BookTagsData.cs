using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Migrations
{
	/// <inheritdoc />
	public partial class Seed50BookTagsData : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
			   table: "BookTags",
			   columns: new[] { "BookId", "TagId" },
			   values: new object[,]
			   {
					// Books 21 to 50 (Other genres)
					{ 21, 4 }, // Dune -> Science Fiction
					{ 22, 4 }, // The Hobbit -> Fantasy
					{ 23, 4 }, // 1984 -> Dystopian
					{ 24, 4 }, // Pride and Prejudice -> Romance
					{ 25, 4 }, // The Great Gatsby -> Historical Fiction
					{ 26, 4 }, // Brave New World -> Dystopian
					{ 27, 4 }, // Fahrenheit 451 -> Dystopian
					{ 28, 4 }, // The Catcher in the Rye -> Literary Fiction
					{ 29, 4 }, // To Kill a Mockingbird -> Literary Fiction
					{ 30, 4 }, // The Alchemist -> Adventure
					{ 31, 4 }, // Animal Farm -> Dystopian
					{ 32, 4 }, // The Picture of Dorian Gray -> Literary Fiction
					{ 33, 4 }, // Gone with the Wind -> Historical Fiction
					{ 34, 4 }, // The Road -> Dystopian
					{ 35, 4 }, // The Fault in Our Stars -> Young Adult
					{ 36, 4 }, // The Maze Runner -> Young Adult
					{ 37, 4 }, // The Hunger Games -> Young Adult
					{ 38, 4 }, // The Kite Runner -> Literary Fiction
					{ 39, 4 }, // Life of Pi -> Literary Fiction
					{ 40, 4 }, // A Game of Thrones -> Fantasy
					{ 41, 4 }, // The Name of the Wind -> Fantasy
					{ 42, 4 }, // Good Omens -> Fantasy
					{ 43, 4 }, // American Gods -> Fantasy
					{ 44, 4 }, // The Girl with the Dragon Tattoo -> Thriller
					{ 45, 4 }, // The Da Vinci Code -> Mystery
					{ 46, 4 }, // The Silence of the Lambs -> Thriller
					{ 47, 4 }, // Where the Crawdads Sing -> Literary Fiction
					{ 48, 4 }, // The Outsider -> Thriller
					{ 49, 4 }, // Big Little Lies -> Literary Fiction
					{ 50, 4 }, // The Night Circus -> Fantasy
					{ 51, 4 }, // Station Eleven -> Dystopian
					{ 52, 4 }, // The Light We Lost -> Romance
					{ 53, 4 }, // The Immortalists -> Literary Fiction
			   });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
			   table: "BookTags",
			   keyColumns: new[] { "BookId", "TagId" },
			   keyValues: new object[,]
			   {
					{ 21, 4 },
					{ 22, 4 },
					{ 23, 4 },
					{ 24, 4 },
					{ 25, 4 },
					{ 26, 4 },
					{ 27, 4 },
					{ 28, 4 },
					{ 29, 4 },
					{ 30, 4 },
					{ 31, 4 },
					{ 32, 4 },
					{ 33, 4 },
					{ 34, 4 },
					{ 35, 4 },
					{ 36, 4 },
					{ 37, 4 },
					{ 38, 4 },
					{ 39, 4 },
					{ 40, 4 },
					{ 41, 4 },
					{ 42, 4 },
					{ 43, 4 },
					{ 44, 4 },
					{ 45, 4 },
					{ 46, 4 },
					{ 47, 4 },
					{ 48, 4 },
					{ 49, 4 },
					{ 50, 4 },
					{ 51, 4 },
					{ 52, 4 },
					{ 53, 4 }
			   });
		}
	}
}
