using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpAnimal.Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "volunteer_information",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "volunter_statistic",
                table: "volunteers");

            migrationBuilder.AddColumn<string>(
                name: "description_value",
                table: "volunteers",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "experience_experience_years",
                table: "volunteers",
                type: "integer",
                maxLength: 60,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description_value",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "experience_experience_years",
                table: "volunteers");

            migrationBuilder.AddColumn<string>(
                name: "volunteer_information",
                table: "volunteers",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "volunter_statistic",
                table: "volunteers",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }
    }
}
