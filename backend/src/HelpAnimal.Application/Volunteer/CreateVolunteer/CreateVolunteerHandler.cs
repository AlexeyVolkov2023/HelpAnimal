using CSharpFunctionalExtensions;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.AnimalManagement.ValueObjects.ID;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.Shared.ValueObject;

namespace HelpAnimal.Application.Volunteer.CreateVolunteer;

public class CreateVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;

    public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
    {
        _volunteersRepository = volunteersRepository;
    }

    public async Task<Result<Guid, Error>> Handle(
        CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var fullNameResult = FullName.Create(
            request.FullNameDto.Name,
            request.FullNameDto.Surname,
            request.FullNameDto.Patronymik);
        if (fullNameResult.IsFailure)
            return fullNameResult.Error;

        var phoneNumberResult = PhoneNumber.Create(request.Number);
        if (phoneNumberResult.IsFailure)
            return phoneNumberResult.Error;

        var emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure)
            return emailResult.Error;

        var descriptionResult = Description.Create(request.Description);
        if (descriptionResult.IsFailure)
            return descriptionResult.Error;

        var expirienceYearsResult = ExsperienceYears.Create(request.ExperienceYears);
        if (expirienceYearsResult.IsFailure)
            return expirienceYearsResult.Error;

        var volunteer = await _volunteersRepository.GetByNumber(phoneNumberResult.Value);

        if (volunteer.IsSuccess)
            return Errors.General.AlreadyExist();

        var volunteerId = VolunteerId.NewVolunteerId();

        var volunteerToCreate = new Domain.AnimalManagement.AggregateRoot.Volunteer(
            volunteerId,
            fullNameResult.Value,
            phoneNumberResult.Value,
            emailResult.Value,
            descriptionResult.Value,
            expirienceYearsResult.Value);

        await _volunteersRepository.Add(volunteerToCreate, cancellationToken);

        return (Guid)volunteerToCreate.Id;
    }
}