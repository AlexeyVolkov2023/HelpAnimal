using HelpAnimal.Application.Volunteer.CreateVolunteer.DTO;

namespace HelpAnimal.Application.Volunteer.CreateVolunteer;

public record CreateVolunteerRequest(
    CreateFullNameFto FullNameFto,
    string Number,
    string Email,
    string Description,
    int ExperienceYears);