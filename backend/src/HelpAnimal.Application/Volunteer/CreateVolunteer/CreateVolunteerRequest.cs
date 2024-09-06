namespace HelpAnimal.Application.Volunteer.CreateVolunteer;

public record CreateVolunteerRequest(
    CreateFullNameDTO FullNameDto,
    string Number,
    string Email,
    string Description,
    int ExperienceYears
);

public record CreateFullNameDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymik { get; set; }
}