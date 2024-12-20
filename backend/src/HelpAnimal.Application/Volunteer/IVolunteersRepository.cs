using CSharpFunctionalExtensions;
using HelpAnimal.Domain.AnimalManagement.ValueObjects.ID;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.AnimalManagement.AggregateRoot;
using HelpAnimal.Domain.Shared.ValueObject;

namespace HelpAnimal.Application.Volunteer;

public interface IVolunteersRepository
{
    Task<Guid> Add(
        Domain.AnimalManagement.AggregateRoot.Volunteer volunteer,
        CancellationToken cancellationToken = default);
    Task<Guid> Save(
        Domain.AnimalManagement.AggregateRoot.Volunteer volunteer,
        CancellationToken cancellationToken = default);  
    Task<Guid> Delete(
        Domain.AnimalManagement.AggregateRoot.Volunteer volunteer,
        CancellationToken cancellationToken = default);
    
    Task<Result<Domain.AnimalManagement.AggregateRoot.Volunteer, Error>> GetById(
        VolunteerId volunteerId,
        CancellationToken cancellationToken = default);
    Task<Result<Domain.AnimalManagement.AggregateRoot.Volunteer, Error>> GetByNumber(
        PhoneNumber number,
        CancellationToken cancellationToken = default);
}