namespace HelpAnimal.Application.Volunteer.CreateVolunteer;

public record CreateVolunteerRequest(
    CreateFullNameDTO FullNameDto,
    string Number,
    string Email,
    string Description,
    int ExperienceYears);

