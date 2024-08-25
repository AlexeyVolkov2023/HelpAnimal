using HelpAnimal.Domain.ForAll;
using HelpAnimal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpAnimal.Infrastructura.Configuration;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("Species");

       builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .HasConversion(
                id => id.Value,
                value => Speciesid.Create(value));

       
        builder.Property(s => s.Name)
            .IsRequired() 
            .HasMaxLength(Constants.LOW_TEXT_LENGTH);

        
        builder.HasMany(s => s.Breeds)
            .WithOne()
            .HasForeignKey("breed_id");
    }
}