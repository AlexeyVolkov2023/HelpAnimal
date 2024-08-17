using HelpAnimal.Domain.ForAll;
using HelpAnimal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpAnimal.Infrastructura.Configuration;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.FullName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_VOLUNTEER_NAME_LENGTH);

        builder.Property(v => v.Description)
            .IsRequired()
            .HasMaxLength(Constants.HIGH_TEXT_LENGTH);

        builder.Property(v => v.ExperienceYears)
            .IsRequired()
            .HasMaxLength(Constants.MAX_EXPERIENCE_YEARS);

        builder.Property(v => v.AdoptedAnimalsCount)
            .IsRequired();

        builder.Property(v => v.CurrentAnimalsCount)
            .IsRequired();

        builder.Property(v => v.AnimalsInTreatmentCount)
            .IsRequired();

        builder.Property(v => v.PhoneNumber)
            .IsRequired()
            .HasMaxLength(Constants.MAX_PHONENUMBER_LENGTH);

        builder.OwnsOne(a => a.SocialNetworks, a =>
        {
            a.ToJson();
            a.OwnsMany(e => e.Networks, d =>
            {
                d.Property(r => r.Name).IsRequired();
                d.Property(r => r.Link).IsRequired();
            });
        });
        
        builder.OwnsOne(a => a.RequisiteCollection, a =>
        {
            a.ToJson();
            a.OwnsMany(e => e.Requisites, d =>
            {
                d.Property(r => r.Title).IsRequired();
                d.Property(r => r.Description).IsRequired();
            });
        });
        
        builder.HasMany(v => v.Animals)
            .WithOne()
            .HasForeignKey("volunteer_id");
    }
}