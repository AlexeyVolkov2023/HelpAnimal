using FluentValidation;
using HelpAnimal.Application.Validation;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.Shared.ValueObject;

namespace HelpAnimal.Application.Volunteer.UpdateMainInfo;

public class UpdateMainInfoRequestValidator : AbstractValidator<UpdateMainInfoRequest>
{
    public UpdateMainInfoRequestValidator()
    {
        RuleFor(u => u.VolunteerId)
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired());
    }
}
public class UpdateMainInfoDtoValidator : AbstractValidator<UpdateMainInfoDto>
{
    public UpdateMainInfoDtoValidator() {
        
        RuleFor(c => c.Phone)
            .MustBeValueObject(PhoneNumber.Create);
        RuleFor(c => c.Description)
            .MustBeValueObject(Description.Create);
        RuleFor(c => c.Email)
            .MustBeValueObject(Email.Create);
        RuleFor(c => c.ExperienceYears)
            .MustBeValueObject(ExsperienceYears.Create);
        
    }
}