using FluentValidation;
using HelpAnimal.Application.Validation;
using HelpAnimal.Application.Volunteer.Dto;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Application.Volunteer.UpdateSocialNetwork;

public class UpdateSocialNetworkRequestValidator : AbstractValidator<UpdateSocialNetworkRequest>
{
    public UpdateSocialNetworkRequestValidator()
    {
        RuleFor(u => u.VolunteerId)
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired());
    }
}

public class UpdateSocialNetworkFtoValidator : AbstractValidator<UpdateSocialNetworkFto>
{
    public UpdateSocialNetworkFtoValidator()
    {
        RuleForEach(c => c.SocialLinks)
            .MustBeValueObject(s => SocialNetwork.Create(s.Network, s.Link));
    }
}


