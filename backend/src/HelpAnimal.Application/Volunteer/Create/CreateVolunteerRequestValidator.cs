using FluentValidation;
using HelpAnimal.Application.Validation;
using HelpAnimal.Application.Volunteer.Create.Dto;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.Shared.ValueObject;


namespace HelpAnimal.Application.Volunteer.Create;

public class CreateVolunteerRequestValidator : AbstractValidator<CreateVolunteerRequest>
{
    public CreateVolunteerRequestValidator()
    {
        RuleFor(c => c.FullNameFto)
            .SetValidator(new CreateFullNameFtoValidator());
        RuleFor(c => c.Number)
            .MustBeValueObject(PhoneNumber.Create);
        RuleFor(c => c.Email)
            .MustBeValueObject(Email.Create);
        RuleFor(c => c.Description)
            .MustBeValueObject(Description.Create);
        RuleFor(c => c.ExperienceYears)
            .MustBeValueObject(ExsperienceYears.Create);
        RuleForEach(c => c.Requisites)
            .MustBeValueObject(s => Requisite.Create(s.Title, s.Description));
        RuleForEach(c => c.Networks)
            .MustBeValueObject(s => SocialNetwork.Create(s.Network, s.Link));
    }
}