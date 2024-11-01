using HelpAnimal.Application.Volunteer.Dto;

namespace HelpAnimal.Application.Volunteer.UpdateSocialNetwork;

public record UpdateSocialNetworkRequest(
    Guid VolunteerId,
    UpdateSocialNetworkFto Networks);