using System.Runtime.InteropServices.JavaScript;
using HelpAnimal.Domain.Shared.ValueObject;

namespace HelpAnimal.Application.Volunteer.UpdateMainInfo;

public record UpdateMainInfoRequest(Guid VolunteerId,UpdateMainInfoDto Dto);
public record UpdateMainInfoDto(
    string Phone, 
    string Description, 
    string Email,
    int ExperienceYears);