using HelpAnimal.Application.Volunteer;
using HelpAnimal.Infrastructura.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HelpAnimal.Infrastructura;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection collection)
    {
        collection.AddScoped<HelpAnimalDbContext>();

        collection.AddScoped<IVolunteersRepository, VolunteersRepository>();

        return collection;
    }
}