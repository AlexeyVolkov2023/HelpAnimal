using FluentValidation;
using HelpAnimal.Application.Validation;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;

namespace HelpAnimal.Application.Volunteer.Create.Dto;

public class CreateFullNameFtoValidator : AbstractValidator<CreateFullNameFto>
{
    public CreateFullNameFtoValidator()
    {
        RuleFor(c => new { c.Name, c.Surname, c.Patronymik })
            .MustBeValueObject(x =>
                FullName.Create(x.Name, x.Surname, x.Patronymik!));
    }
}