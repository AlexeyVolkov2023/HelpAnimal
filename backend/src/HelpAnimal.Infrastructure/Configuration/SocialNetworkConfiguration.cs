using Microsoft.EntityFrameworkCore;
using HelpAnimal.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpAnimal.Infrastructura.Configuration;

public class SocialNetworkConfiguration : IEntityTypeConfiguration<SocialNetwork>
{
    public void Configure(EntityTypeBuilder<SocialNetwork> builder)
    {
        builder.ToTable("social_networks"); 

        builder.HasKey(sn => sn.Id);

        builder.Property(sn => sn.Id)
            .ValueGeneratedOnAdd(); 

        builder.Property(sn => sn.Name)
            .IsRequired();

        builder.Property(sn => sn.Link)
           .IsRequired();
    }
}