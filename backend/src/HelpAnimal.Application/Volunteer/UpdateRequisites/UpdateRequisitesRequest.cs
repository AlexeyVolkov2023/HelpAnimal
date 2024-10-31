using HelpAnimal.Application.Volunteer.Dto;

namespace HelpAnimal.Application.Volunteer.UpdateRequisites;

public record UpdateRequisitesRequest( Guid VolunteerId, UpdateRequisitesFto Fto);