using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookTagsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seeding BookTags entries
            migrationBuilder.InsertData(
                table: "BookTags",
                columns: new[] { "BookId", "TagId" },
                values: new object[,]
                {
                { 77, 9 },  // Dune -> Advanced Programming
                { 77, 11 }, // Dune -> ASP.NET Core
                { 78, 6 },  // The Hobbit -> Game Development
                { 79, 10 }, // 1984 -> Beginner Programming
                { 79, 16 }, // 1984 -> Cybersecurity
                { 80, 47 }, // Pride and Prejudice -> User Experience
                { 81, 36 }, // The Great Gatsby -> E-commerce
                { 82, 56 }, // Brave New World -> Computer Vision
                { 83, 46 }, // Fahrenheit 451 -> Testing Automation
                { 84, 62 }, // The Catcher in the Rye -> Health Tech
                { 85, 53 }, // To Kill a Mockingbird -> Content Management Systems
                { 86, 11 }, // The Alchemist -> ASP.NET Core
                { 87, 12 }, // Animal Farm -> Unity
                { 88, 49 }, // The Picture of Dorian Gray -> Ethical Hacking
                { 89, 43 }, // Gone with the Wind -> Human-Computer Interaction
                { 90, 59 }, // The Road -> Augmented Analytics
                { 91, 38 }, // The Fault in Our Stars -> Mobile Apps
                { 92, 22 }, // The Maze Runner -> Microservices
                { 93, 19 }, // The Hunger Games -> Mobile Development
                { 94, 63 }, // The Kite Runner -> FinTech
                { 95, 47 }, // Life of Pi -> User Experience
                { 96, 6 },  // A Game of Thrones -> Game Development
                { 97, 48 }, // The Name of the Wind -> User Interface
                { 98, 37 }, // Good Omens -> Game Design
                { 99, 20 }, // American Gods -> Data Science
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Removing the seeded data in case of rollback
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 77, 9 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 77, 11 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 78, 6 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 79, 10 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 79, 16 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 80, 47 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 81, 36 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 82, 56 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 83, 46 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 84, 62 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 85, 53 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 86, 11 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 87, 12 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 88, 49 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 89, 43 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 90, 59 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 91, 38 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 92, 22 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 93, 19 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 94, 63 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 95, 47 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 96, 6 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 97, 48 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 98, 37 });
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumns: new[] { "BookId", "TagId" },
                keyValues: new object[] { 99, 20 });
        }
    }
}
