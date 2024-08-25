using HelpAnimal.Domain.ForAll;
using HelpAnimal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpAnimal.Infrastructura.Configuration;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("Breeds");

       builder.HasKey(b => b.Id);
       
       builder.Property(b => b.Id)
           .HasConversion(
               id => id.Value,
               value => Breedid.Create(value));

       
        builder.Property(b => b.Title)
            .IsRequired() 
            .HasMaxLength(Constants.LOW_TEXT_LENGTH); 

      
    }
}