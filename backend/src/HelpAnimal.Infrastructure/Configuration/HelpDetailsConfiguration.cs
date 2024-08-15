using Microsoft.EntityFrameworkCore;
using HelpAnimal.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpAnimal.Infrastructura.Configuration;

public class HelpDetailsConfiguration : IEntityTypeConfiguration<HelpDetail>
{
    public void Configure(EntityTypeBuilder<HelpDetail> builder)
    {
        builder.ToTable("help_details"); 
        
        builder.HasKey(hd => hd.Id);
        
        builder.Property(sn => sn.Id)
            .ValueGeneratedOnAdd(); 

        builder.Property(hd => hd.Requisite)
            .IsRequired(); 

        builder.Property(hd => hd.Description)
            .IsRequired(); 
    }
}