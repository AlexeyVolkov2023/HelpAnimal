using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpAnimal.Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class CommentsAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "already_vaccinated",
                table: "animals");

            migrationBuilder.RenameColumn(
                name: "animal_addresses",
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

            migrationBuilder.AddColumn<string>(
                name: "full_name_patronymic",
                table: "volunteers",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "animals",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<string>(
                name: "animal_address_city",
                table: "animals",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "animal_address_country",
                table: "animals",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "animal_address_number_home",
                table: "animals",
                type: "integer",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "animal_address_street",
                table: "animals",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "full_name_patronymic",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "animal_address_city",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "animal_address_country",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "animal_address_number_home",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "animal_address_street",
                table: "animals");

            migrationBuilder.RenameColumn(
                name: "already_vaccination",
                table: "animals",
                newName: "animal_addresses");

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

            migrationBuilder.AddColumn<string>(
                name: "already_vaccinated",
                table: "animals",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }
    }
}
