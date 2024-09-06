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

    public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        await _dbContext.Volunteers.AddAsync(volunteer, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return volunteer.Id;
    }

    public async Task<Result<Volunteer, Error>> GetById(VolunteerId volunteerId)
    {
        var volunteer = await _dbContext.Volunteers
            .Include(v => v.Animals) 
            .Include(v => v.SocialNetworks) 
            .Include(v => v.RequisiteCollection) 
            .FirstOrDefaultAsync(v => v.Id == volunteerId);

        if (volunteer is null)
            return Errors.General.NotFound(volunteerId);

        return volunteer;
    }

    public async Task<Result<Volunteer, Error>> GetByNumber(PhoneNumber number)
    {
        var volunteer = await _dbContext.Volunteers
            .Include(v => v.Animals) 
            .Include(v => v.SocialNetworks) 
            .Include(v => v.RequisiteCollection) 
            .FirstOrDefaultAsync(v => v.Phone == number);

        if (volunteer is null)
            return Errors.General.NotFound();

        return volunteer;
    }
}