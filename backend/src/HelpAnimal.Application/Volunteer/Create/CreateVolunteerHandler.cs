using CSharpFunctionalExtensions;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.AnimalManagement.ValueObjects.ID;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.Shared.ValueObject;
using Microsoft.Extensions.Logging;

namespace HelpAnimal.Application.Volunteer.Create;

public class CreateVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;
    private readonly ILogger<CreateVolunteerHandler> _logger;

    public CreateVolunteerHandler(
        IVolunteersRepository volunteersRepository,
        ILogger<CreateVolunteerHandler> logger)
    {
        _volunteersRepository = volunteersRepository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var fullName = FullName.Create(
            request.FullNameFto.Name,
            request.FullNameFto.Surname,
            request.FullNameFto.Patronymik!).Value;

        var phoneNumber = PhoneNumber.Create(request.Number).Value;

        var email = Email.Create(request.Email).Value;
       
        var description = Description.Create(request.Description).Value;

        var expirienceYears = ExsperienceYears.Create(request.ExperienceYears).Value;

        var requisites = new RequisiteDetails
        (request.Requisites.Select
            (r => Requisite.Create(r.Title, r.Description).Value));
        
        var networks = new SocialDetails
        (request.Networks.Select
            (r => SocialNetwork.Create(r.Network, r.Link).Value));
        
        var volunteer = await _volunteersRepository.GetByNumber(phoneNumber);

        if (volunteer.IsSuccess)
            return Errors.General.AlreadyExist();

        var volunteerId = VolunteerId.NewVolunteerId();

        var volunteerToCreate = new Domain.AnimalManagement.AggregateRoot.Volunteer(
            volunteerId,
            fullName,
            phoneNumber,
            email,
            description,
            expirienceYears,
            networks,
            requisites);

        await _volunteersRepository.Add(volunteerToCreate, cancellationToken);
        
        _logger.LogInformation("Created volunteer with Id {volunteerId}", volunteerId);

        return (Guid)volunteerToCreate.Id;
    }
}