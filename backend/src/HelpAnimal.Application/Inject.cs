using HelpAnimal.Application.Volunteer.CreateVolunteer;
using Microsoft.Extensions.DependencyInjection;

namespace HelpAnimal.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<CreateVolunteerHandler>();

        return collection;
    }
}