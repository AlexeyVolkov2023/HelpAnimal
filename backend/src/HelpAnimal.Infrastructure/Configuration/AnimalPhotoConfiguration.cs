using HelpAnimal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpAnimal.Infrastructura.Configuration;

public class AnimalPhotoConfiguration : IEntityTypeConfiguration<AnimalPhoto>
{
    public void Configure(EntityTypeBuilder<AnimalPhoto> builder)
    {
        builder.ToTable("animal_photos");
        
        builder.HasKey(ap => ap.Id);
        
        builder.Property(sn => sn.Id)
            .ValueGeneratedOnAdd(); 

        builder.Property(ap => ap.StoragePath)
            .IsRequired();

        builder.Property(ap => ap.IsMain)
            .IsRequired();

    }
}