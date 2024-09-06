namespace HelpAnimal.Application.Volunteer.CreateVolunteer;

public record CreateVolunteerRequest(
    string Name, 
    string Surname,
    string Patronymik,
    string Number,
    string Email,
    string Description,
    int ExperienceYears
    );


