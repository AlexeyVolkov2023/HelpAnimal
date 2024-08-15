using HelpAnimal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace HelpAnimal.Infrastructure;

public class HelpAnimalDbContext (IConfiguration configuration) : DbContext
{
    private const string ALEX = "Alex";
    
    
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Volunteer> Volunteers { get; set; }
    public DbSet<HelpDetail> HelpDetails { get; set; }
    public DbSet<SocialNetwork> SocialNetworks { get; set; }
    public DbSet<AnimalPhoto> AnimalPhotos { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString(ALEX ));
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
    }

    private ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => { builder.AddConsole(); });

}