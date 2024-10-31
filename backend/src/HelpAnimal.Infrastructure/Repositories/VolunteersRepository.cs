using CSharpFunctionalExtensions;
using HelpAnimal.Application.Volunteer;
using HelpAnimal.Domain.AnimalManagement.AggregateRoot;
using HelpAnimal.Domain.AnimalManagement.ValueObjects.ID;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.Shared.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace HelpAnimal.Infrastructura.Repositories;

public class VolunteersRepository : IVolunteersRepository
{
    private readonly HelpAnimalDbContext _dbContext;

    public VolunteersRepository(HelpAnimalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Add(
        Volunteer volunteer,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Volunteers.AddAsync(volunteer, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return volunteer.Id;
    }

    public async Task<Guid> Save(
        Volunteer volunteer,
        CancellationToken cancellationToken = default)
    {
        _dbContext.Volunteers.Attach(volunteer);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return volunteer.Id;
    }

    public async Task<Guid> Delete(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        _dbContext.Volunteers.Remove(volunteer);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return volunteer.Id;
    }


    public async Task<Result<Volunteer, Error>> GetById(
        VolunteerId volunteerId,
        CancellationToken cancellationToken = default)
    {
        var volunteer = await _dbContext.Volunteers
            .Include(v => v.Animals)
            .FirstOrDefaultAsync(v => v.Id == volunteerId, cancellationToken);

        var entries1 = _dbContext.ChangeTracker.Entries<Volunteer>();

        if (volunteer is null)
            return Errors.General.NotFound(volunteerId);

        return volunteer;
    }

    public async Task<Result<Volunteer, Error>> GetByNumber(
        PhoneNumber number,
        CancellationToken cancellationToken = default)
    {
        var volunteer = await _dbContext.Volunteers
            .Include(v => v.Animals)
            .FirstOrDefaultAsync(v => v.Phone == number, cancellationToken);

        if (volunteer is null)
            return Errors.General.NotFound();

        return volunteer;
    }
}