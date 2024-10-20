using FluentValidation;
using HelpAnimal.Application.Volunteer.Create.Dto;

namespace HelpAnimal.Application.Volunteer.Create;

public record CreateVolunteerRequest(
    CreateFullNameFto FullNameFto,
    string Number,
    string Email,
    string Description,
    int ExperienceYears,
    IEnumerable<CreateRequisiteFto> Requisites,
    IEnumerable<CreateSocialNetworkFto> Networks);
    
