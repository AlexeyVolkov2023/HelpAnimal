using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpAnimal.Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class CreateValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "full_name",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "address",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "is_vaccinated",
                table: "animals");

            migrationBuilder.RenameColumn(
                name: "owner_contact_number",
                table: "animals",
                newName: "phone_number");

            migrationBuilder.AddColumn<string>(
                name: "full_name_name",
                table: "volunteers",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "full_name_surname",
                table: "volunteers",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "already_vaccinated",
                table: "animals",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "animal_addresses",
                table: "animals",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "full_name_name",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "full_name_surname",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "already_vaccinated",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "animal_addresses",
                table: "animals");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "animals",
                newName: "owner_contact_number");

            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "volunteers",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "animals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_vaccinated",
                table: "animals",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
