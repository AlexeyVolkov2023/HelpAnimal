using HelpAnimal.Infrastructura;
using Microsoft.EntityFrameworkCore;

namespace HelpAnimal.API;

public static class AppExtensions
{
    public static async Task ApplyMigration(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<HelpAnimalDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}