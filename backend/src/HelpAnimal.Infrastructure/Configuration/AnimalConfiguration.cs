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
            pb.Property(a => a.Name)
                .HasMaxLength(Constants.NAME_MAX_LENGTH)
                .IsRequired();
            pb.Property(a => a.Description)
                .HasMaxLength(Constants.HIGH_TEXT_LENGTH)
                    .IsRequired();
        });

        builder.OwnsOne(a => a.Identifier, ab =>
        {
            ab.ToJson("identifier_animal");
            ab.OwnsOne(ia => ia.SpeciesIdentifier,
                sb =>
                {
                    sb.Property(s => s.Value);
                });
            ab.Property(d => d.BreedGuid);
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


        builder.OwnsOne(a => a.AnimalAddress, ab =>
        {
            ab.ToJson("animal_address");
            ab.Property(d => d.Country)
                .IsRequired()
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);
            ab.Property(d => d.City)
                .IsRequired()
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);
            ab.Property(d => d.Street)
                .IsRequired()
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);
            ab.Property(d => d.NumberHome)
                .IsRequired()
                .HasMaxLength(Constants.LOW_TEXT_LENGTH);
        });

        builder.ComplexProperty(a => a.Phone, pb =>
        {
            pb.IsRequired();
            pb.Property(pn => pn.Number)
                .HasMaxLength(Constants.MAX_PHONENUMBER_LENGTH);
        });
        
        builder.ComplexProperty(a => a.Birthday, bb =>
        {
            bb.IsRequired();
            bb.Property(a => a.Birthday);
        });

        builder.OwnsOne(a => a.AlreadyVaccinated, ab =>
        {
            ab.ToJson("already_vaccination");
            ab.OwnsMany(v => v.Vaccinations, vb =>
            {
                vb.Property(v => v.NameVaccine)
                    .IsRequired()
                    .HasMaxLength(Constants.LOW_TEXT_LENGTH);
                vb.Property(v => v.DateVaccination)
                    .IsRequired();
            });
        });

        builder.ComplexProperty(a => a.Status, sb =>
        {
            sb.IsRequired();
            sb.Property(s => s.Value)
                .IsRequired();
        });


        builder.OwnsOne(a => a.AnimalPhotos, apb =>
        {
            apb.ToJson("animal_photos");
            apb.OwnsMany(p => p.Photos, pd =>
            {
                pd.Property(p => p.StoragePath)
                    .IsRequired();
                pd.Property(p => p.IsMain)
                    .IsRequired();
            });
        });

        builder.OwnsOne(a => a.RequisiteCollection, rcb =>
        {
            rcb.ToJson("requisite_collection");
            rcb.OwnsMany(e => e.Requisites, rb =>
            {
                rb.Property(r => r.Title)
                    .IsRequired()
                    .HasMaxLength(Constants.LOW_TEXT_LENGTH);
                rb.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.HIGH_TEXT_LENGTH);
            });
        });
    }
}