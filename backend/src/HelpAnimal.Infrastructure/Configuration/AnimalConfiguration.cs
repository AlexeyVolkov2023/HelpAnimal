using HelpAnimal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Constants = HelpAnimal.Domain.ForAll.Constants;

namespace HelpAnimal.Infrastructura.Configuration;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("animals"); 
       
        builder.HasKey(a => a.Id);
        
        builder.Property(v => v.Id)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_ANIMAL_NAME_LENGTH);

        builder.Property(a => a.Species)
            .IsRequired();

        builder.Property(a => a.Description)
            .IsRequired()
            .HasMaxLength(Constants.HIGH_TEXT_LENGTH);;

        builder.Property(a => a.Breed)
            .IsRequired();;

        builder.Property(a => a.Color)
            .IsRequired();;

        builder.Property(a => a.HealthInfo)
            .IsRequired()
            .HasMaxLength(Constants.MEDIUM_TEXT_LENGTH);;

        builder.Property(a => a.Address)
            .IsRequired();;

        builder.Property(a => a.Weight)
            .IsRequired();

        builder.Property(a => a.Height)
            .IsRequired();

        builder.Property(a => a.OwnerContactNumber)
            .HasMaxLength(Constants.MAX_PHONENUMBER_LENGTH);

        builder.Property(a => a.IsNeutered)
            .IsRequired();

        builder.Property(a => a.DateOfBirth)
            .IsRequired();

        builder.Property(a => a.IsVaccinated)
            .IsRequired();

        builder.Property(a => a.Status)
            .IsRequired();

        builder.HasMany(a => a.Photos)
            .WithOne()
            .HasForeignKey("animal_id");

        builder.HasMany(a => a.Requisite)
            .WithOne()
            .HasForeignKey("animal_id");


    }
    
}