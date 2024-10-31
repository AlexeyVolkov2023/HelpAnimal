using HelpAnimal.Domain.AnimalManagement.AggregateRoot;
using HelpAnimal.Domain.SpeciesManagement.AggregateRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HelpAnimal.Infrastructura;

public class HelpAnimalDbContext(IConfiguration configuration) : DbContext
{
    private const string ALEX = "Alex";

    public DbSet<Volunteer> Volunteers { get; set; }
    public DbSet<Species> Specieses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString(ALEX));
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HelpAnimalDbContext).Assembly);
    }

    private ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => { builder.AddConsole(); });
}