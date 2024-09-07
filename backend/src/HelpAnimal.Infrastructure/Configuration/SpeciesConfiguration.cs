using HelpAnimal.Domain.SpeciesManagement.AggregateRoot;
using HelpAnimal.Domain.SpeciesManagement.ID;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpAnimal.Infrastructura.Configuration;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");

        builder.HasKey(s => s.Id);

        builder.Property(a => a.Id)
            .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value));

        builder.Property(s => s.Title)
            .IsRequired().HasMaxLength(Species.MAX_TITLE_SPECIES_LENGTH);

        builder.HasMany(s => s.Breeds)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}