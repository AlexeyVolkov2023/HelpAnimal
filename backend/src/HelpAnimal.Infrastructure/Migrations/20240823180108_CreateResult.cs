using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpAnimal.Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class CreateResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "already_vaccinated",
                table: "animals",
                newName: "already_vaccination");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "volunteers",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "animals",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "already_vaccination",
                table: "animals",
                newName: "already_vaccinated");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "volunteers",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "animals",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);
        }
    }
}
