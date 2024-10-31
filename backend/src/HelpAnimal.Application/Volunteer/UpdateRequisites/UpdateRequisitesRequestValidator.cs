using FluentValidation;
using HelpAnimal.Application.Validation;
using HelpAnimal.Application.Volunteer.Dto;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.Shared.ValueObject;

namespace HelpAnimal.Application.Volunteer.UpdateRequisites;

public class UpdateRequisitesRequestValidator :AbstractValidator<UpdateRequisitesRequest>
{
   public UpdateRequisitesRequestValidator()
   {
      RuleFor(u => u.VolunteerId)
         .NotEmpty()
         .WithError(Errors.General.ValueIsRequired());
   }
}

public class UpdateRequisitesFtoValidator :AbstractValidator<UpdateRequisitesFto>
{
   public UpdateRequisitesFtoValidator()
   {
      RuleForEach(c => c.Requisites)
         .MustBeValueObject(r => Requisite.Create(r.Title, r.Description));
   }
}