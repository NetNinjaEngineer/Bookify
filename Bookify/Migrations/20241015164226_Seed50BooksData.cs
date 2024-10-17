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
                    "Title", "Description", "ImageName", "Price", "GenreId", "AuthorId", "StockQuantity",
                    "EditionLanguage", "BookFormat", "Pages", "Lessons", "IsOnSale", "DatePublished", "PublisherId"
                },
                values: new object[,]
                {
                    { "Dune", "A science fiction novel set in the distant future.", "dune.jpeg", 9.99m, 1, 30, 100, EditionLanguage.English.ToString(), "Paperback", 412, 0, false, DateTimeOffset.Now, 11 },
                    { "The Hobbit", "A fantasy novel about a hobbit's adventure.", "hobbit.jpeg", 14.99m, 2, 31, 150, EditionLanguage.English.ToString(), "Hardcover", 310, 0, false, DateTimeOffset.Now, 12 },
                    { "1984", "A dystopian novel about totalitarianism.", "1984.jpeg", 8.99m, 10, 30, 200, EditionLanguage.English.ToString(), "Paperback", 328, 0, false, DateTimeOffset.Now, 9 },
                    { "Pride and Prejudice", "A romantic novel about manners.", "pride.jpeg", 12.99m, 4, 21, 80, EditionLanguage.English.ToString(), "Paperback", 279, 0, false, DateTimeOffset.Now, 13 },
                    { "The Great Gatsby", "A novel about the American dream.", "gatsby.jpeg", 10.99m, 7, 32, 120, EditionLanguage.English.ToString(), "Paperback", 180, 0, true, DateTimeOffset.Now, 18 },
                    { "Brave New World", "A dystopian novel about a future society.", "brave_new_world.jpeg", 11.99m, 10, 33, 90, EditionLanguage.English.ToString(), "Paperback", 268, 0, false, DateTimeOffset.Now, 17 },
                    { "Fahrenheit 451", "A novel about a future where books are banned.", "fahrenheit_451.jpeg", 9.49m, 10, 34, 150, EditionLanguage.English.ToString(), "Paperback", 158, 0, true, DateTimeOffset.Now, 9 },
                    { "The Catcher in the Rye", "A novel about teenage rebellion.", "catcher_in_the_rye.jpeg", 10.99m, 3, 35, 120, EditionLanguage.English.ToString(), "Paperback", 277, 0, false, DateTimeOffset.Now, 13 },
                    { "To Kill a Mockingbird", "A novel about racial injustice.", "to_kill_a_mockingbird.jpeg", 12.49m, 4, 36, 200, EditionLanguage.English.ToString(), "Paperback", 281, 0, false, DateTimeOffset.Now, 18 },
                    { "The Alchemist", "A novel about following your dreams.", "the_alchemist.jpeg", 15.99m, 1, 37, 100, EditionLanguage.English.ToString(), "Paperback", 208, 0, true, DateTimeOffset.Now, 11 },
                    { "Animal Farm", "A satirical allegory about politics.", "animal_farm.jpeg", 8.99m, 10, 38, 250, EditionLanguage.English.ToString(), "Paperback", 112, 0, false, DateTimeOffset.Now, 12 },
                    { "The Picture of Dorian Gray", "A novel about vanity and moral corruption.", "dorian_gray.jpeg", 12.99m, 7, 39, 90, EditionLanguage.English.ToString(), "Paperback", 254, 0, true, DateTimeOffset.Now, 9 },
                    { "Gone with the Wind", "A historical novel about the American South.", "gone_with_the_wind.jpeg", 14.99m, 7, 40, 60, EditionLanguage.English.ToString(), "Paperback", 1037, 0, false, DateTimeOffset.Now, 11 },
                    { "The Road", "A post-apocalyptic novel about survival.", "the_road.jpeg", 11.99m, 11, 41, 80, EditionLanguage.English.ToString(), "Paperback", 287, 0, true, DateTimeOffset.Now, 12 },
                    { "The Fault in Our Stars", "A young adult novel about love and illness.", "fault_in_our_stars.jpeg", 9.99m, 11, 42, 100, EditionLanguage.English.ToString(), "Hardcover", 313, 0, false, DateTimeOffset.Now, 13 },
                    { "The Maze Runner", "A dystopian novel about a group of teens.", "maze_runner.jpeg", 10.99m, 10, 43, 150, EditionLanguage.English.ToString(), "Paperback", 374, 0, false, DateTimeOffset.Now, 12 },
                    { "The Hunger Games", "A dystopian novel about survival.", "hunger_games.jpeg", 12.99m, 10, 44, 100, EditionLanguage.English.ToString(), "Hardcover", 374, 0, true, DateTimeOffset.Now, 11 },
                    { "The Kite Runner", "A novel about friendship and redemption.", "kite_runner.jpeg", 13.99m, 4, 45, 80, EditionLanguage.English.ToString(), "Hardcover", 371, 0, false, DateTimeOffset.Now, 9 },
                    { "Life of Pi", "A novel about survival and spirituality.", "life_of_pi.jpeg", 11.99m, 4, 46, 150, EditionLanguage.English.ToString(), "Hardcover", 319, 0, true, DateTimeOffset.Now, 12 },
                    { "A Game of Thrones", "The first book in the epic fantasy series.", "game_of_thrones.jpeg", 15.99m, 2, 47, 60, EditionLanguage.English.ToString(), "Hardcover", 694, 0, false, DateTimeOffset.Now, 11 },
                    { "The Name of the Wind", "A fantasy novel about a gifted young man.", "name_of_the_wind.jpeg", 14.99m, 2, 48, 100, EditionLanguage.English.ToString(), "Hardcover", 662, 0, true, DateTimeOffset.Now, 12 },
                    { "Good Omens", "A comedic novel about the apocalypse.", "good_omens.jpeg", 12.49m, 2, 49, 150, EditionLanguage.English.ToString(), "Paperback", 400, 0, false, DateTimeOffset.Now, 10 },
                    { "American Gods", "A fantasy novel about gods in modern America.", "american_gods.jpeg", 13.99m, 2, 50, 100, EditionLanguage.English.ToString(), "Paperback", 465, 0, false, DateTimeOffset.Now, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "Books",
               keyColumn: "Title",
               keyValues: new object[]
               {
                   "Dune", "The Hobbit", "1984", "Pride and Prejudice", "The Great Gatsby",
                   "Brave New World", "Fahrenheit 451", "The Catcher in the Rye", "To Kill a Mockingbird",
                   "The Alchemist", "Animal Farm", "The Picture of Dorian Gray", "Gone with the Wind",
                   "The Road", "The Fault in Our Stars", "The Maze Runner", "The Hunger Games",
                   "The Kite Runner", "Life of Pi", "A Game of Thrones", "The Name of the Wind",
                   "Good Omens", "American Gods"
               });
        }
    }
}
