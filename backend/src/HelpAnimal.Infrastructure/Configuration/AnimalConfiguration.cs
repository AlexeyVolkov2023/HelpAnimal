using HelpAnimal.Domain.AnimalManagement.Entities;
using HelpAnimal.Domain.AnimalManagement.ValueObjects.ID;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Constants = HelpAnimal.Domain.Shared.Constants;

namespace HelpAnimal.Infrastructura.Configuration;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("animals");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasConversion(
                id => id.Value,
                value => AnimalId.Create(value));

        builder.OwnsOne(a => a.Profile, pb =>
        {
            pb.ToJson("animal_profile");
            pb.Property(ad => ad.Name)
                .HasMaxLength(Constants.NAME_MAX_LENGTH)
                .IsRequired();
            pb.Property(ad => ad.Description)
                .HasMaxLength(Constants.HIGH_TEXT_LENGTH)
                    .IsRequired();
        });

        builder.OwnsOne(a => a.Identifier, ai =>
        {
            ai.ToJson("identifier_animal");
            ai.OwnsOne(b => b.SpeciesIdentifier, c => { c.Property(d => d.Value); });
            ai.Property(d => d.BreedGuid);
        });

        builder.OwnsOne(a => a.Information, ib =>
        {
            ib.ToJson("animal_information");
            ib.Property(b => b.HealthInfo)
                .IsRequired()
                .HasMaxLength(Constants.MEDIUM_TEXT_LENGTH);
            ib.Property(b => b.Color)
                .IsRequired();
            ib.Property(b => b.Height)
                .IsRequired();
            ib.Property(b => b.Weight)
                .IsRequired();
            ib.Property(b => b.IsNeutered)
                .IsRequired();
        });


        builder.OwnsOne(a => a.AnimalAddress, aa =>
        {
            aa.ToJson("animal_address");
            aa.Property(b => b.Country)
                .IsRequired()
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);
            aa.Property(d => d.City)
                .IsRequired()
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);
            aa.Property(d => d.Street)
                .IsRequired()
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);
            aa.Property(d => d.NumberHome)
                .IsRequired()
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);
        });

        builder.ComplexProperty(a => a.Phone, b =>
        {
            b.IsRequired();
            b.Property(p => p.Number)
                .HasMaxLength(Constants.MAX_PHONENUMBER_LENGTH);
        });

        builder.Property(a => a.DateOfBirth)
            .IsRequired();

        builder.OwnsOne(a => a.AlreadyVaccinated, av =>
        {
            av.ToJson("already_vaccination");
            av.OwnsMany(v => v.Vaccinations, b =>
            {
                b.Property(d => d.NameVaccine)
                    .IsRequired()
                    .HasMaxLength(Constants.LOW_TEXT_LENGTH);
                b.Property(d => d.DateVaccination)
                    .IsRequired();
            });
        });

        builder.ComplexProperty(a => a.Status, b =>
        {
            b.IsRequired();
            b.Property(c => c.Value)
                .IsRequired();
        });


        builder.OwnsOne(a => a.AnimalPhotos, a =>
        {
            a.ToJson("animal_photos");
            a.OwnsMany(e => e.Photos, d =>
            {
                d.Property(r => r.StoragePath)
                    .IsRequired();
                d.Property(r => r.IsMain)
                    .IsRequired();
            });
        });

        builder.OwnsOne(a => a.RequisiteCollection, a =>
        {
            a.ToJson("requisite_collection");
            a.OwnsMany(e => e.Requisites, d =>
            {
                d.Property(r => r.Title)
                    .IsRequired()
                    .HasMaxLength(Constants.LOW_TEXT_LENGTH);
                d.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.HIGH_TEXT_LENGTH);
            });
        });
    }
}