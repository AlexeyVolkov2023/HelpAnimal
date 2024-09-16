using System.ComponentModel.DataAnnotations;
using CSharpFunctionalExtensions;
using FluentValidation;
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
        var fullName = FullName.Create(
            request.FullNameFto.Name,
            request.FullNameFto.Surname,
            request.FullNameFto.Patronymik!).Value;

        var phoneNumber = PhoneNumber.Create(request.Number).Value;

        var email = Email.Create(request.Email).Value;
       
        var description = Description.Create(request.Description).Value;

        var expirienceYears = ExsperienceYears.Create(request.ExperienceYears).Value;

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
            expirienceYears);

        await _volunteersRepository.Add(volunteerToCreate, cancellationToken);

        return (Guid)volunteerToCreate.Id;
    }
}