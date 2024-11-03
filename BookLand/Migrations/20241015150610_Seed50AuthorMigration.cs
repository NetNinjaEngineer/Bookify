using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Migrations
{
	/// <inheritdoc />
	public partial class Seed50AuthorMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
			table: "Authors",
			columns: new[] { "FirstName", "LastName" },
			values: new object[,]
			{
				{ "Jane", "Austen" },
				{ "Charles", "Dickens" },
				{ "George", "Orwell" },
				{ "F. Scott", "Fitzgerald" },
				{ "Ernest", "Hemingway" },
				{ "J.K.", "Rowling" },
				{ "Mark", "Twain" },
				{ "Virginia", "Woolf" },
				{ "Toni", "Morrison" },
				{ "Isaac", "Asimov" },
				{ "J.R.R.", "Tolkien" },
				{ "Agatha", "Christie" },
				{ "Stephen", "King" },
				{ "C.S.", "Lewis" },
				{ "Gabriel", "Garcia Marquez" },
				{ "Chimamanda", "Ngozi Adichie" },
				{ "Harper", "Lee" },
				{ "Ray", "Bradbury" },
				{ "Margaret", "Atwood" },
				{ "Kurt", "Vonnegut" },
				{ "Dan", "Brown" },
				{ "Neil", "Gaiman" },
				{ "Dante", "Alighieri" },
				{ "Herman", "Melville" },
				{ "Leo", "Tolstoy" },
				{ "Friedrich", "Nietzsche" },
				{ "John", "Steinbeck" },
				{ "Philip", "K. Dick" },
				{ "Arthur", "C. Clarke" },
				{ "W. Somerset", "Maugham" },
				{ "Oscar", "Wilde" },
				{ "David", "Mitchell" },
				{ "John", "Grisham" },
				{ "Zadie", "Smith" },
				{ "Colson", "Whitehead" },
				{ "Jhumpa", "Lahiri" },
				{ "Terry", "Pratchett" },
				{ "Jasmine", "Warga" },
				{ "Louise", "Erdich" },
				{ "Ernest", "J. Gaines" },
				{ "Salman", "Rushdie" },
				{ "Cormac", "McCarthy" },
				{ "N. K.", "Jemisin" },
				{ "Cynthia", "Ozick" },
				{ "Tom", "Robbins" },
				{ "Doris", "Lessing" },
				{ "Pablo", "Neruda" },
				{ "Stephen", "R. Donaldson" },
				{ "Gabriel", "García" },
				{ "Elena", "Ferrante" },
				{ "Marie", "Kondo" },
				{ "Aldous", "Huxley" },
				{ "George", "Eliot" },
				{ "Alice", "Walker" },
				{ "Richard", "P. Feynman" }
			});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
			table: "Authors",
			keyColumns: new[] { "FirstName", "LastName" },
			keyValues: new object[,]
			{
				{ "Jane", "Austen" },
				{ "Charles", "Dickens" },
				{ "George", "Orwell" },
				{ "F. Scott", "Fitzgerald" },
				{ "Ernest", "Hemingway" },
				{ "J.K.", "Rowling" },
				{ "Mark", "Twain" },
				{ "Virginia", "Woolf" },
				{ "Toni", "Morrison" },
				{ "Isaac", "Asimov" },
				{ "J.R.R.", "Tolkien" },
				{ "Agatha", "Christie" },
				{ "Stephen", "King" },
				{ "C.S.", "Lewis" },
				{ "Gabriel", "Garcia Marquez" },
				{ "Chimamanda", "Ngozi Adichie" },
				{ "Harper", "Lee" },
				{ "Ray", "Bradbury" },
				{ "Margaret", "Atwood" },
				{ "Kurt", "Vonnegut" },
				{ "Dan", "Brown" },
				{ "Neil", "Gaiman" },
				{ "Dante", "Alighieri" },
				{ "Herman", "Melville" },
				{ "Leo", "Tolstoy" },
				{ "Friedrich", "Nietzsche" },
				{ "John", "Steinbeck" },
				{ "Philip", "K. Dick" },
				{ "Arthur", "C. Clarke" },
				{ "W. Somerset", "Maugham" },
				{ "Oscar", "Wilde" },
				{ "David", "Mitchell" },
				{ "John", "Grisham" },
				{ "Zadie", "Smith" },
				{ "Colson", "Whitehead" },
				{ "Jhumpa", "Lahiri" },
				{ "Terry", "Pratchett" },
				{ "Jasmine", "Warga" },
				{ "Louise", "Erdich" },
				{ "Ernest", "J. Gaines" },
				{ "Salman", "Rushdie" },
				{ "Cormac", "McCarthy" },
				{ "N. K.", "Jemisin" },
				{ "Cynthia", "Ozick" },
				{ "Tom", "Robbins" },
				{ "Doris", "Lessing" },
				{ "Pablo", "Neruda" },
				{ "Stephen", "R. Donaldson" },
				{ "Gabriel", "García" },
				{ "Elena", "Ferrante" },
				{ "Marie", "Kondo" },
				{ "Aldous", "Huxley" },
				{ "George", "Eliot" },
				{ "Alice", "Walker" },
				{ "Richard", "P. Feynman" }
			});

		}
	}
}
