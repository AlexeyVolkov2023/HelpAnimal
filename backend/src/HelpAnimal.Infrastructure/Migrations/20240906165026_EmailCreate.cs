using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpAnimal.Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class EmailCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email_value",
                table: "volunteers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email_value",
                table: "volunteers");
        }
    }
}
