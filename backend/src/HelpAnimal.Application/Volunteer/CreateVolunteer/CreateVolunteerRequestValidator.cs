using FluentValidation;
using HelpAnimal.Application.Validation;
using HelpAnimal.Application.Volunteer.CreateVolunteer.DTO;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.Shared.ValueObject;

namespace HelpAnimal.Application.Volunteer.CreateVolunteer;

public class CreateVolunteerRequestValidator : AbstractValidator<CreateVolunteerRequest>
{
    public CreateVolunteerRequestValidator()
    {
        RuleFor(c => c.FullNameFto).SetValidator(new CreateFullNameFtoValidator());
        RuleFor(c => c.Number).MustBeValueObject(PhoneNumber.Create);
        RuleFor(c => c.Email).MustBeValueObject(Email.Create);
        RuleFor(c => c.Description).MustBeValueObject(Description.Create);
        RuleFor(c => c.ExperienceYears).MustBeValueObject(ExsperienceYears.Create);
    }
}