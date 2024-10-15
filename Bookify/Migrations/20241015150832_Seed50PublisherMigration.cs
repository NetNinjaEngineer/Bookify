using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Migrations
{
	/// <inheritdoc />
	public partial class Seed50PublisherMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
		   table: "Publishers",
		   columns: new[] { "PublisherName" },
		   values: new object[,]
		   {
				{ "Springer" },
				{ "Elsevier" },
				{ "Taylor & Francis" },
				{ "Cambridge University Press" },
				{ "McGraw-Hill" },
				{ "SAGE Publications" },
				{ "Routledge" },
				{ "John Wiley & Sons" },
				{ "Pearson" },
				{ "Berrett-Koehler Publishers" },
				{ "Houghton Mifflin Harcourt" },
				{ "HarperCollins" },
				{ "Random House" },
				{ "Simon & Schuster" },
				{ "Scholastic" },
				{ "Thomson Reuters" },
				{ "Hachette Livre" },
				{ "Rowman & Littlefield" },
				{ "Kogan Page" },
				{ "MIT Press" },
				{ "Northwestern University Press" },
				{ "University of California Press" },
				{ "Stanford University Press" },
				{ "Yale University Press" },
				{ "University of Chicago Press" },
				{ "Duke University Press" },
				{ "Harvard University Press" },
				{ "Oxford University Press" },
				{ "Princeton University Press" },
				{ "Columbia University Press" },
				{ "University of Toronto Press" },
				{ "University of Michigan Press" },
				{ "Zondervan" },
				{ "Lippincott Williams & Wilkins" },
				{ "Springer Nature" },
				{ "Wiley-Blackwell" },
				{ "Cambridge University Press" },
				{ "Elsevier" },
				{ "American Psychological Association" },
				{ "McMillan" },
				{ "Garnet Publishing" },
				{ "Avery Publishing" },
				{ "Baker Publishing Group" },
				{ "Beacon Press" },
				{ "Counterpoint Press" },
				{ "Chronicle Books" },
				{ "Kirkus Media" },
				{ "Skyhorse Publishing" },
				{ "WestBow Press" },
				{ "Hachette Book Group" },
				{ "Workman Publishing" }
		   });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
		  table: "Publishers",
		  keyColumn: "PublisherName",
		  keyValues: new object[]
		  {
				"Springer", "Elsevier", "Taylor & Francis", "Cambridge University Press",
				"McGraw-Hill", "SAGE Publications", "Routledge", "John Wiley & Sons",
				"Pearson", "Berrett-Koehler Publishers", "Houghton Mifflin Harcourt",
				"HarperCollins", "Random House", "Simon & Schuster", "Scholastic",
				"Thomson Reuters", "Hachette Livre", "Rowman & Littlefield",
				"Kogan Page", "MIT Press", "Northwestern University Press",
				"University of California Press", "Stanford University Press",
				"Yale University Press", "University of Chicago Press",
				"Duke University Press", "Harvard University Press",
				"Oxford University Press", "Princeton University Press",
				"Columbia University Press", "University of Toronto Press",
				"University of Michigan Press", "Zondervan",
				"Lippincott Williams & Wilkins", "Springer Nature",
				"Wiley-Blackwell", "Cambridge University Press",
				"Elsevier", "American Psychological Association", "McMillan",
				"Garnet Publishing", "Avery Publishing", "Baker Publishing Group",
				"Beacon Press", "Counterpoint Press", "Chronicle Books",
				"Kirkus Media", "Skyhorse Publishing", "WestBow Press",
				"Hachette Book Group", "Workman Publishing"
		  });
		}
	}
}
