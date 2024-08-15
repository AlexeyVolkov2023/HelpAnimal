﻿// <auto-generated />
using System;
using HelpAnimal.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HelpAnimal.Infrastructura.Migrations
{
    [DbContext(typeof(HelpAnimalDbContext))]
    [Migration("20240815121307_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HelpAnimal.Domain.Models.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("breed");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("HealthInfo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("health_info");

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("height");

                    b.Property<bool>("IsNeutered")
                        .HasColumnType("boolean")
                        .HasColumnName("is_neutered");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_vaccinated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("OwnerContactNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("owner_contact_number");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("species");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid?>("VolunteerId")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("pk_animals");

                    b.HasIndex("VolunteerId")
                        .HasDatabaseName("ix_animals_volunteer_id");

                    b.ToTable("animals", (string)null);
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.AnimalPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("AnimalId")
                        .HasColumnType("uuid")
                        .HasColumnName("animal_id");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean")
                        .HasColumnName("is_main");

                    b.Property<string>("StoragePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("storage_path");

                    b.HasKey("Id")
                        .HasName("pk_animal_photos");

                    b.HasIndex("AnimalId")
                        .HasDatabaseName("ix_animal_photos_animal_id");

                    b.ToTable("animal_photos", (string)null);
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.HelpDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("AnimalId")
                        .HasColumnType("uuid")
                        .HasColumnName("animal_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Requisite")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("requisite");

                    b.Property<Guid?>("VolunteerId")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.HasKey("Id")
                        .HasName("pk_help_details");

                    b.HasIndex("AnimalId")
                        .HasDatabaseName("ix_help_details_animal_id");

                    b.HasIndex("VolunteerId")
                        .HasDatabaseName("ix_help_details_volunteer_id");

                    b.ToTable("help_details", (string)null);
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.SocialNetwork", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("link");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid?>("VolunteerId")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.HasKey("Id")
                        .HasName("pk_social_networks");

                    b.HasIndex("VolunteerId")
                        .HasDatabaseName("ix_social_networks_volunteer_id");

                    b.ToTable("social_networks", (string)null);
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("AdoptedAnimalsCount")
                        .HasColumnType("integer")
                        .HasColumnName("adopted_animals_count");

                    b.Property<int>("AnimalsInTreatmentCount")
                        .HasColumnType("integer")
                        .HasColumnName("animals_in_treatment_count");

                    b.Property<int>("CurrentAnimalsCount")
                        .HasColumnType("integer")
                        .HasColumnName("current_animals_count");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("ExperienceYears")
                        .HasColumnType("integer")
                        .HasColumnName("experience_years");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_volunteers");

                    b.ToTable("volunteers", (string)null);
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.Animal", b =>
                {
                    b.HasOne("HelpAnimal.Domain.Models.Volunteer", null)
                        .WithMany("Animals")
                        .HasForeignKey("VolunteerId")
                        .HasConstraintName("fk_animals_volunteers_volunteer_id");
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.AnimalPhoto", b =>
                {
                    b.HasOne("HelpAnimal.Domain.Models.Animal", null)
                        .WithMany("Photos")
                        .HasForeignKey("AnimalId")
                        .HasConstraintName("fk_animal_photos_animals_animal_id");
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.HelpDetail", b =>
                {
                    b.HasOne("HelpAnimal.Domain.Models.Animal", null)
                        .WithMany("Requisite")
                        .HasForeignKey("AnimalId")
                        .HasConstraintName("fk_help_details_animals_animal_id");

                    b.HasOne("HelpAnimal.Domain.Models.Volunteer", null)
                        .WithMany("Requisite")
                        .HasForeignKey("VolunteerId")
                        .HasConstraintName("fk_help_details_volunteers_volunteer_id");
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.SocialNetwork", b =>
                {
                    b.HasOne("HelpAnimal.Domain.Models.Volunteer", null)
                        .WithMany("SocialNetworks")
                        .HasForeignKey("VolunteerId")
                        .HasConstraintName("fk_social_networks_volunteers_volunteer_id");
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.Animal", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("Requisite");
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.Volunteer", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Requisite");

                    b.Navigation("SocialNetworks");
                });
#pragma warning restore 612, 618
        }
    }
}
