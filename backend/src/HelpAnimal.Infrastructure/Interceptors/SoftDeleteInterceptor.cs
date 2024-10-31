using HelpAnimal.Domain.AnimalManagement.AggregateRoot;
using HelpAnimal.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HelpAnimal.Infrastructure.Interceptors;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (eventData.Context is null)
        {
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        
        var entries = eventData.Context.ChangeTracker
            .Entries()
            .Where(e => e.State == EntityState.Deleted);
        
        foreach (var entry in entries)
        {
            if (entry.Entity is ISoftDeletable item)
            {
                entry.State = EntityState.Modified;
                item.Delete();
            }
        }
        
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
        
    }
}