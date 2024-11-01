using FluentValidation;
using HelpAnimal.Application.Volunteer.Dto;

namespace HelpAnimal.Application.Volunteer.Create;

public record CreateVolunteerRequest(
    CreateFullNameFto FullNameFto,
    string Phone,
    string Email,
    string Description,
    int ExperienceYears,
    IEnumerable<RequisiteFto> Requisites,
    IEnumerable<SocialNetworkFto> Networks);
    
