using Bookify.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Migrations
{
	/// <inheritdoc />
	public partial class Seed50BooksData : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
			table: "Books",
			columns: new[]
			{
				"Title", "Description", "ImageName", "Price", "GenreId", "AuthorId", "StockQuantity", "ISBN",
				"EditionLanguage", "BookFormat", "Pages", "Lessons", "IsOnSale", "DatePublished", "PublisherId"
			},
			values: new object[,]
			{
				{ "Dune", "A science fiction novel set in the distant future.", "dune.jpg", 9.99m, 1, 30, 100, "978-0441013593", EditionLanguage.English.ToString(), "Paperback", 412, 0, false, DateTimeOffset.Now, 11 },
				{ "The Hobbit", "A fantasy novel about a hobbit's adventure.", "hobbit.jpg", 14.99m, 2, 31, 150, "978-0618260300", EditionLanguage.English.ToString(), "Hardcover", 310, 0, false, DateTimeOffset.Now, 12 },
				{ "1984", "A dystopian novel about totalitarianism.", "1984.jpg", 8.99m, 10, 30, 200, "978-0451524935", EditionLanguage.English.ToString(), "Paperback", 328, 0, false, DateTimeOffset.Now, 9 },
				{ "Pride and Prejudice", "A romantic novel about manners.", "pride.jpg", 12.99m, 4, 21, 80, "978-1503290563", EditionLanguage.English.ToString(), "Paperback", 279, 0, false, DateTimeOffset.Now, 13 },
				{ "The Great Gatsby", "A novel about the American dream.", "gatsby.jpg", 10.99m, 7, 32, 120, "978-0743273565", EditionLanguage.English.ToString(), "Paperback", 180, 0, true, DateTimeOffset.Now, 18 },
				{ "Brave New World", "A dystopian novel about a future society.", "brave_new_world.jpg", 11.99m, 10, 33, 90, "978-0060850524", EditionLanguage.English.ToString().ToString(), "Paperback", 268, 0, false, DateTimeOffset.Now, 17 },
				{ "Fahrenheit 451", "A novel about a future where books are banned.", "fahrenheit_451.jpg", 9.49m, 10, 34, 150, "978-1451673319", EditionLanguage.English.ToString(), "Paperback", 158, 0, true, DateTimeOffset.Now, 9 },
				{ "The Catcher in the Rye", "A novel about teenage rebellion.", "catcher_in_the_rye.jpg", 10.99m, 3, 35, 120, "978-0316769488", EditionLanguage.English.ToString(), "Paperback", 277, 0, false, DateTimeOffset.Now, 13 },
				{ "To Kill a Mockingbird", "A novel about racial injustice.", "to_kill_a_mockingbird.jpg", 12.49m, 4, 36, 200, "978-0061120084", EditionLanguage.English.ToString(), "Paperback", 281, 0, false, DateTimeOffset.Now, 18 },
				{ "The Alchemist", "A novel about following your dreams.", "the_alchemist.jpg", 15.99m, 1, 37, 100, "978-0061122415", EditionLanguage.English.ToString(), "Paperback", 208, 0, true, DateTimeOffset.Now, 11 },
				{ "Animal Farm", "A satirical allegory about politics.", "animal_farm.jpg", 8.99m, 10, 38, 250, "978-0451526342", EditionLanguage.English.ToString(), "Paperback", 112, 0, false, DateTimeOffset.Now, 12 },
				{ "The Picture of Dorian Gray", "A novel about vanity and moral corruption.", "dorian_gray.jpg", 12.99m, 7, 39, 90, "978-0141439570", EditionLanguage.English.ToString(), "Paperback", 254, 0, true, DateTimeOffset.Now, 9 },
				{ "Gone with the Wind", "A historical novel about the American South.", "gone_with_the_wind.jpg", 14.99m, 7, 40, 60, "978-1451635621", EditionLanguage.English.ToString(), "Paperback", 1037, 0, false, DateTimeOffset.Now, 11 },
				{ "The Road", "A post-apocalyptic novel about survival.", "the_road.jpg", 11.99m, 11, 41, 80, "978-0307387899", EditionLanguage.English.ToString(), "Paperback", 287, 0, true, DateTimeOffset.Now, 12 },
				{ "The Fault in Our Stars", "A young adult novel about love and illness.", "fault_in_our_stars.jpg", 9.99m, 11, 42, 100, "978-0525478812", EditionLanguage.English.ToString(), "Hardcover", 313, 0, false, DateTimeOffset.Now, 13 },
				{ "The Maze Runner", "A dystopian novel about a group of teens.", "maze_runner.jpg", 10.99m, 10, 43, 150, "978-0385737951", EditionLanguage.English.ToString(), "Paperback", 374, 0, false, DateTimeOffset.Now, 12 },
				{ "The Hunger Games", "A dystopian novel about survival.", "hunger_games.jpg", 12.99m, 10, 44, 100, "978-0439023528", EditionLanguage.English.ToString(), "Hardcover", 374, 0, true, DateTimeOffset.Now, 11 },
				{ "The Kite Runner", "A novel about friendship and redemption.", "kite_runner.jpg", 13.99m, 4, 45, 80, "978-1594631931", EditionLanguage.English.ToString(), "Hardcover", 371, 0, false, DateTimeOffset.Now, 9 },
				{ "Life of Pi", "A novel about survival and spirituality.", "life_of_pi.jpg", 11.99m, 4, 46, 150, "978-0156027328", EditionLanguage.English.ToString(), "Hardcover", 319, 0, true, DateTimeOffset.Now, 12 },
				{ "A Game of Thrones", "The first book in the epic fantasy series.", "game_of_thrones.jpg", 15.99m, 2, 47, 60, "978-0553103540", EditionLanguage.English.ToString(), "Hardcover", 694, 0, false, DateTimeOffset.Now, 11 },
				{ "The Name of the Wind", "A fantasy novel about a gifted young man.", "name_of_the_wind.jpg", 14.99m, 2, 48, 100, "978-0756404741", EditionLanguage.English.ToString(), "Hardcover", 662, 0, true, DateTimeOffset.Now, 12 },
				{ "Good Omens", "A comedic novel about the apocalypse.", "good_omens.jpg", 12.49m, 2, 49, 150, "978-0060853983", EditionLanguage.English.ToString(), "Paperback", 400, 0, false, DateTimeOffset.Now, 10 },
				{ "American Gods", "A fantasy novel about gods in modern America.", "american_gods.jpg", 13.99m, 2, 50, 100, "978-0062572230", EditionLanguage.English.ToString(), "Paperback", 465, 0, false, DateTimeOffset.Now, 9 },
				{ "The Girl with the Dragon Tattoo", "A thriller about a journalist and a hacker.", "girl_with_dragon_tattoo.jpg", 14.99m, 3, 51, 90, "978-0307454546", EditionLanguage.English.ToString(), "Hardcover", 465, 0, true, DateTimeOffset.Now, 12 },
				{ "The Da Vinci Code", "A mystery thriller involving a murder in the Louvre.", "da_vinci_code.jpg", 11.99m, 3, 52, 120, "978-0307474278", EditionLanguage.English.ToString(), "Hardcover", 454, 0, false, DateTimeOffset.Now, 9 },
				{ "The Silence of the Lambs", "A thriller about an FBI trainee.", "silence_of_the_lambs.jpg", 9.99m, 3, 53, 200, "978-1250072234", EditionLanguage.English.ToString(), "Paperback", 368, 0, true, DateTimeOffset.Now, 10 },
				{ "Where the Crawdads Sing", "A novel about a young girl in the marshes of North Carolina.", "where_the_crawdads_sing.jpg", 12.99m, 4, 54, 80, "978-0735219113", EditionLanguage.English.ToString(), "Hardcover", 368, 0, false, DateTimeOffset.Now, 11 },
				{ "The Outsider", "A novel about an investigation into a murder.", "the_outsider.jpg", 10.99m, 3, 55, 150, "978-1501180989", EditionLanguage.English.ToString(), "Hardcover", 576, 0, true, DateTimeOffset.Now, 12 },
				{ "Big Little Lies", "A novel about secrets and lies among friends.", "big_little_lies.jpg", 11.49m, 4, 56, 100, "978-0425274866", EditionLanguage.English.ToString(), "Hardcover", 460, 0, false, DateTimeOffset.Now, 10 },
				{ "The Night Circus", "A novel about a magical competition.", "the_night_circus.jpg", 12.99m, 2, 57, 80, "978-0385534643", EditionLanguage.English.ToString(), "Hardcover", 387, 0, true, DateTimeOffset.Now, 9 },
				{ "Station Eleven", "A novel about a post-apocalyptic world.", "station_eleven.jpg", 13.99m, 10, 58, 120, "978-0345803525", EditionLanguage.English.ToString(), "Paperback", 333, 0, false, DateTimeOffset.Now, 11 },
				{ "The Light We Lost", "A love story set against the backdrop of 9/11.", "the_light_we_lost.jpg", 11.99m, 4, 59, 150, "978-1476753185", EditionLanguage.English.ToString(), "Hardcover", 368, 0, true, DateTimeOffset.Now, 12 },
				{ "The Immortalists", "A novel about four siblings and their futures.", "the_immortalists.jpg", 10.99m, 4, 60, 100, "978-0735213173", EditionLanguage.English.ToString(), "Hardcover", 368, 0, false, DateTimeOffset.Now, 11 }
			});

		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
			   table: "Books",
			   keyColumn: "ISBN",
			   keyValues: new object[]
			   {
					"978-0441013593",
					"978-0618260300",
					"978-0451524935",
					"978-1503290563",
					"978-0743273565",
					"978-0060850524",
					"978-0451526342",
					"978-0316769488",
					"978-0061120084",
					"978-0061122415",
					"978-0385737951",
					"978-0439023528",
					"978-1594631931",
					"978-0156027328",
					"978-0553103540",
					"978-0756404741",
					"978-0060853983",
					"978-0062572230",
					"978-0307454546",
					"978-0307474278",
					"978-1250072234",
					"978-0735219113",
					"978-1501180989",
					"978-0425274866",
					"978-0385534643",
					"978-0345803525",
					"978-1476753185",
					"978-0735213173"
			   });
		}
	}
}
