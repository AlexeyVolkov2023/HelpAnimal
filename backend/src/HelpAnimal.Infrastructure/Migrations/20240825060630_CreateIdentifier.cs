using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpAnimal.Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdentifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "breed",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "species",
                table: "animals");

            migrationBuilder.AddColumn<string>(
                name: "animal_identifier",
                table: "animals",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    breed_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_breeds", x => x.id);
                    table.ForeignKey(
                        name: "fk_breeds_species_breed_id",
                        column: x => x.breed_id,
                        principalTable: "Species",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_breeds_breed_id",
                table: "Breeds",
                column: "breed_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropColumn(
                name: "animal_identifier",
                table: "animals");

            migrationBuilder.AddColumn<string>(
                name: "breed",
                table: "animals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "species",
                table: "animals",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
