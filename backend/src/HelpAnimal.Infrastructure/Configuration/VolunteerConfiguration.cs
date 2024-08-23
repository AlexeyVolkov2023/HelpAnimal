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

       builder.ComplexProperty(a => a.FullName, b =>
       {
          b.Property(c => c.Name)
              .IsRequired()
              .HasMaxLength(Constants.NAME_MAX_LENGTH);
          b.Property(c => c.Surname)
              .IsRequired()
              .HasMaxLength(FullName.SURNAME_MAX_LENGTH);;
       });

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

        builder.ComplexProperty(a => a.Phone, b =>
        {
            b.IsRequired();
            b.Property(c => c.Number)
                .HasMaxLength(Constants.MAX_PHONENUMBER_LENGTH);
        });

        builder.OwnsOne(a => a.SocialNetworks, a =>
        {
            a.ToJson("social_networks");
            a.OwnsMany(e => e.Networks, d =>
            {
                d.Property(r => r.Title)
                    .IsRequired();
                d.Property(r => r.Link)
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
        
        builder.HasMany(v => v.Animals)
            .WithOne()
            .HasForeignKey("volunteer_id");
    }
}