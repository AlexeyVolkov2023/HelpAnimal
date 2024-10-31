using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace HelpAnimal.Application.Volunteer.Delete;

public class DeleteVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;
    private readonly ILogger<DeleteVolunteerHandler> _logger;

    public DeleteVolunteerHandler(
        IVolunteersRepository volunteersRepository,
        ILogger<DeleteVolunteerHandler> logger)
    {
        _volunteersRepository = volunteersRepository;
        _logger = logger;
    } 
    
    public async Task<Result<Guid, Error>> Handle(
        DeleteVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var volunteerResult = await _volunteersRepository.GetById(request.VolunteerId, cancellationToken);
        if (volunteerResult.IsFailure)
        {
            return volunteerResult.Error;
        }
        
        volunteerResult.Value.Delete();
        
        var result = await _volunteersRepository.Delete(volunteerResult.Value, cancellationToken);
        
        _logger.LogInformation("Deleted volunteer with Id {volunteerId}", request.VolunteerId);
        
        return result;
    }
}