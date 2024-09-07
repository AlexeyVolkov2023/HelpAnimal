using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.SpeciesManagement.Entities;
using HelpAnimal.Domain.SpeciesManagement.ID;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpAnimal.Infrastructura.Configuration;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("breeds");

        builder.HasKey(b => b.Id);
        
        builder.Property(a => a.Id)
            .HasConversion(
                id => id.Value,
                value => BreedId.Create(value));

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(Constants.LOW_TEXT_LENGTH);
    }
}