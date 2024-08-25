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

        builder.Property(a => a.Id)
            .HasConversion(
                id => id.Value,
                value => Speciesid.Create(value));

        builder.Property(s => s.Title)
            .IsRequired().HasMaxLength(Species.MAX_TITLE_SPECIES_LENGTH);

        builder.HasMany(s => s.Breeds)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}