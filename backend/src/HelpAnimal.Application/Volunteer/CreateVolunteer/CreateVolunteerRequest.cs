using HelpAnimal.Application.Volunteer.CreateVolunteer.DTO;

namespace HelpAnimal.Application.Volunteer.CreateVolunteer;

public record CreateVolunteerRequest(
    CreateFullNameDTO FullNameDTO,
    string Number,
    string Email,
    string Description,
    int ExperienceYears);