using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpAnimal.Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class RefactorDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adopted_animals_count",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "animals_in_treatment_count",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "current_animals_count",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "description",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "experience_years",
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

            migrationBuilder.DropColumn(
                name: "color",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "description",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "health_info",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "height",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "is_neutered",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "name",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "animals");

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

            migrationBuilder.AddColumn<string>(
                name: "animal_address",
                table: "animals",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "animal_information",
                table: "animals",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "animal_profile",
                table: "animals",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "volunteer_information",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "volunter_statistic",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "animal_address",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "animal_information",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "animal_profile",
                table: "animals");

            migrationBuilder.AddColumn<int>(
                name: "adopted_animals_count",
                table: "volunteers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "animals_in_treatment_count",
                table: "volunteers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "current_animals_count",
                table: "volunteers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "volunteers",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "experience_years",
                table: "volunteers",
                type: "integer",
                maxLength: 60,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "animal_address_city",
                table: "animals",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "animal_address_country",
                table: "animals",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "animal_address_number_home",
                table: "animals",
                type: "integer",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "animal_address_street",
                table: "animals",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "animals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "animals",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "health_info",
                table: "animals",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "height",
                table: "animals",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "is_neutered",
                table: "animals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "animals",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "weight",
                table: "animals",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
