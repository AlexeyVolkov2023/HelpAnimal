using HelpAnimal.Domain.AnimalManagement.AggregateRoot;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.AnimalManagement.ValueObjects.ID;
using HelpAnimal.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpAnimal.Infrastructura.Configuration;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value));

        builder.ComplexProperty(v => v.FullName, fb =>
        {
            fb.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(Constants.NAME_MAX_LENGTH);
            fb.Property(f => f.Surname)
                .IsRequired()
                .HasMaxLength(FullName.SURNAME_MAX_LENGTH);
            fb.Property(f => f.Patronymic)
                .IsRequired()
                .HasMaxLength(FullName.PATRONYMIC_MAX_LENGTH);
        });

        builder.ComplexProperty(v => v.Phone, pb =>
        {
            pb.IsRequired();
            pb.Property(p => p.Number)
                .HasMaxLength(Constants.MAX_PHONENUMBER_LENGTH);
        });

        builder.ComplexProperty(v => v.Email, eb =>
        {
            eb.IsRequired();
            eb.Property(e => e.Value);
        });

        builder.ComplexProperty(v => v.Description, db =>
        {
            db.IsRequired();
            db.Property(d => d.Value)
                .HasMaxLength(Constants.HIGH_TEXT_LENGTH);
        });

        builder.ComplexProperty(v => v.Experience, eb =>
        {
            eb.IsRequired();
            eb.Property(e => e.ExperienceYears)
                .HasMaxLength(Constants.MAX_EXPERIENCE_YEARS);
        });


        builder.OwnsOne(v => v.SocialNetworks, sb =>
        {
            sb.ToJson("social_networks");
            sb.OwnsMany(sd => sd.Networks, nb =>
            {
                nb.Property(s => s.Network)
                    .IsRequired();
                nb.Property(s => s.Link)
                    .IsRequired();
            });
        });

        builder.OwnsOne(v => v.RequisiteCollection, rcb =>
        {
            rcb.ToJson("requisite_collection");
            rcb.OwnsMany(rd => rd.Requisites, rb =>
            {
                rb.Property(r => r.Title)
                    .IsRequired()
                    .HasMaxLength(Constants.LOW_TEXT_LENGTH);
                rb.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.HIGH_TEXT_LENGTH);
            });
        });

        builder.HasMany(v => v.Animals)
            .WithOne()
            .HasForeignKey("volunteer_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property<bool>("_isDeleted")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("is_deleted");


    }
}