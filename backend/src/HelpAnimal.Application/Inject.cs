using FluentValidation;
using HelpAnimal.Application.Volunteer.Create;
using HelpAnimal.Application.Volunteer.Delete;
using HelpAnimal.Application.Volunteer.UpdateMainInfo;
using HelpAnimal.Application.Volunteer.UpdateSocialNetwork;
using Microsoft.Extensions.DependencyInjection;

namespace HelpAnimal.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<CreateVolunteerHandler>();
        collection.AddScoped<UpdateMainInfoHandler>();
        collection.AddScoped<DeleteVolunteerHandler>();
        collection.AddScoped<UpdateSocialNetworkHandler>();

        collection.AddValidatorsFromAssembly(typeof(Inject).Assembly);

        return collection;
    }
}