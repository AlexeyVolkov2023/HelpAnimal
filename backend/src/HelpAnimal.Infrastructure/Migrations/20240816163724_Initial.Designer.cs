﻿// <auto-generated />
using System;
using System.Collections.Generic;
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
    [Migration("20240816163724_Initial")]
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
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<string>("HealthInfo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
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
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("name");

                    b.Property<string>("OwnerContactNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("owner_contact_number");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("species");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.Property<Guid?>("volunteer_id")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.ComplexProperty<Dictionary<string, object>>("Status", "HelpAnimal.Domain.Models.Animal.Status#HelpStatus", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("status_value");
                        });

                    b.HasKey("Id")
                        .HasName("pk_animals");

                    b.HasIndex("volunteer_id")
                        .HasDatabaseName("ix_animals_volunteer_id");

                    b.ToTable("animals", (string)null);
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
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<int>("ExperienceYears")
                        .HasMaxLength(30)
                        .HasColumnType("integer")
                        .HasColumnName("experience_years");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("full_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_volunteers");

                    b.ToTable("volunteers", (string)null);
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.Animal", b =>
                {
                    b.HasOne("HelpAnimal.Domain.Models.Volunteer", null)
                        .WithMany("Animals")
                        .HasForeignKey("volunteer_id")
                        .HasConstraintName("fk_animals_volunteers_volunteer_id");

                    b.OwnsOne("HelpAnimal.Domain.Models.RequisiteDetails", "RequisiteCollection", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uuid");

                            b1.HasKey("AnimalId")
                                .HasName("pk_animals");

                            b1.ToTable("animals");

                            b1.ToJson("requisite_collection");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId")
                                .HasConstraintName("fk_animals_animals_animal_id");

                            b1.OwnsMany("HelpAnimal.Domain.Models.Requisite", "Requisites", b2 =>
                                {
                                    b2.Property<Guid>("RequisiteDetailsAnimalId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("RequisiteDetailsAnimalId", "Id");

                                    b2.ToTable("animals");

                                    b2.ToJson("requisite_collection");

                                    b2.WithOwner()
                                        .HasForeignKey("RequisiteDetailsAnimalId")
                                        .HasConstraintName("fk_animals_animals_requisite_details_animal_id");
                                });

                            b1.Navigation("Requisites");
                        });

                    b.OwnsOne("HelpAnimal.Domain.Models.AnimalPhotosDetails", "AnimalPhotos", b1 =>
                        {
                            b1.Property<Guid>("AnimalId")
                                .HasColumnType("uuid");

                            b1.HasKey("AnimalId");

                            b1.ToTable("animals");

                            b1.ToJson("animal_photos");

                            b1.WithOwner()
                                .HasForeignKey("AnimalId")
                                .HasConstraintName("fk_animals_animals_id");

                            b1.OwnsMany("HelpAnimal.Domain.Models.AnimalPhoto", "Photos", b2 =>
                                {
                                    b2.Property<Guid>("AnimalPhotosDetailsAnimalId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<bool>("IsMain")
                                        .HasColumnType("boolean");

                                    b2.Property<string>("StoragePath")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("AnimalPhotosDetailsAnimalId", "Id");

                                    b2.ToTable("animals");

                                    b2.ToJson("animal_photos");

                                    b2.WithOwner()
                                        .HasForeignKey("AnimalPhotosDetailsAnimalId")
                                        .HasConstraintName("fk_animals_animals_animal_photos_details_animal_id");
                                });

                            b1.Navigation("Photos");
                        });

                    b.Navigation("AnimalPhotos")
                        .IsRequired();

                    b.Navigation("RequisiteCollection")
                        .IsRequired();
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.Volunteer", b =>
                {
                    b.OwnsOne("HelpAnimal.Domain.Models.SocialDetails", "SocialNetworks", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("volunteers");

                            b1.ToJson("social_networks");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_id");

                            b1.OwnsMany("HelpAnimal.Domain.Models.SocialNetwork", "Networks", b2 =>
                                {
                                    b2.Property<Guid>("SocialDetailsVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Link")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("SocialDetailsVolunteerId", "Id");

                                    b2.ToTable("volunteers");

                                    b2.ToJson("social_networks");

                                    b2.WithOwner()
                                        .HasForeignKey("SocialDetailsVolunteerId")
                                        .HasConstraintName("fk_volunteers_volunteers_social_details_volunteer_id");
                                });

                            b1.Navigation("Networks");
                        });

                    b.OwnsOne("HelpAnimal.Domain.Models.RequisiteDetails", "RequisiteCollection", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("volunteers");

                            b1.ToJson("requisite_collection");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_id");

                            b1.OwnsMany("HelpAnimal.Domain.Models.Requisite", "Requisites", b2 =>
                                {
                                    b2.Property<Guid>("RequisiteDetailsVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Title")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("RequisiteDetailsVolunteerId", "Id");

                                    b2.ToTable("volunteers");

                                    b2.ToJson("requisite_collection");

                                    b2.WithOwner()
                                        .HasForeignKey("RequisiteDetailsVolunteerId")
                                        .HasConstraintName("fk_volunteers_volunteers_requisite_details_volunteer_id");
                                });

                            b1.Navigation("Requisites");
                        });

                    b.Navigation("RequisiteCollection")
                        .IsRequired();

                    b.Navigation("SocialNetworks")
                        .IsRequired();
                });

            modelBuilder.Entity("HelpAnimal.Domain.Models.Volunteer", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}