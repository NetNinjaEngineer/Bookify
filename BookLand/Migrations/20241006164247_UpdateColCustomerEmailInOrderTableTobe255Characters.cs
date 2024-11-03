using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColCustomerEmailInOrderTableTobe255Characters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Orders",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Orders",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);
        }
    }
}
