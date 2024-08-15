using System;
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
            migrationBuilder.CreateTable(
                name: "volunteers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    experience_years = table.Column<int>(type: "integer", nullable: false),
                    adopted_animals_count = table.Column<int>(type: "integer", nullable: false),
                    current_animals_count = table.Column<int>(type: "integer", nullable: false),
                    animals_in_treatment_count = table.Column<int>(type: "integer", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_volunteers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "animals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    species = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    breed = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    health_info = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    height = table.Column<double>(type: "double precision", nullable: false),
                    owner_contact_number = table.Column<string>(type: "text", nullable: false),
                    is_neutered = table.Column<bool>(type: "boolean", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_vaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_animals", x => x.id);
                    table.ForeignKey(
                        name: "fk_animals_volunteers_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "volunteers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "social_networks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    link = table.Column<string>(type: "text", nullable: false),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_social_networks", x => x.id);
                    table.ForeignKey(
                        name: "fk_social_networks_volunteers_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "volunteers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "animal_photos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    storage_path = table.Column<string>(type: "text", nullable: false),
                    is_main = table.Column<bool>(type: "boolean", nullable: false),
                    animal_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_animal_photos", x => x.id);
                    table.ForeignKey(
                        name: "fk_animal_photos_animals_animal_id",
                        column: x => x.animal_id,
                        principalTable: "animals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "help_details",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    requisite = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    animal_id = table.Column<Guid>(type: "uuid", nullable: true),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_help_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_help_details_animals_animal_id",
                        column: x => x.animal_id,
                        principalTable: "animals",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_help_details_volunteers_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "volunteers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_animal_photos_animal_id",
                table: "animal_photos",
                column: "animal_id");

            migrationBuilder.CreateIndex(
                name: "ix_animals_volunteer_id",
                table: "animals",
                column: "volunteer_id");

            migrationBuilder.CreateIndex(
                name: "ix_help_details_animal_id",
                table: "help_details",
                column: "animal_id");

            migrationBuilder.CreateIndex(
                name: "ix_help_details_volunteer_id",
                table: "help_details",
                column: "volunteer_id");

            migrationBuilder.CreateIndex(
                name: "ix_social_networks_volunteer_id",
                table: "social_networks",
                column: "volunteer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animal_photos");

            migrationBuilder.DropTable(
                name: "help_details");

            migrationBuilder.DropTable(
                name: "social_networks");

            migrationBuilder.DropTable(
                name: "animals");

            migrationBuilder.DropTable(
                name: "volunteers");
        }
    }
}
