using FluentValidation;
using HelpAnimal.Application.Validation;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Application.Volunteer.Delete;

public class DeleteVolunteerRequestValidator : AbstractValidator<DeleteVolunteerRequest>
{
    public DeleteVolunteerRequestValidator()
    {
        RuleFor(d => d.VolunteerId)
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired());
    }
}