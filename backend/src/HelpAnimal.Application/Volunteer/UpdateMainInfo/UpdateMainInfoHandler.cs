using CSharpFunctionalExtensions;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.Shared.ValueObject;
using Microsoft.Extensions.Logging;

namespace HelpAnimal.Application.Volunteer.UpdateMainInfo;

public class UpdateMainInfoHandler
{
    private readonly IVolunteersRepository _volunteersRepository;
    private readonly ILogger<UpdateMainInfoHandler> _logger;

    public UpdateMainInfoHandler (
        IVolunteersRepository volunteersRepository,
        ILogger<UpdateMainInfoHandler> logger)
    {
        _volunteersRepository = volunteersRepository;
        _logger = logger;
    }
    public async Task<Result<Guid, Error>> Handle(
        UpdateMainInfoRequest request,
        CancellationToken cancellationToken = default)
    {
        var volunteerResult = await _volunteersRepository.GetById(request.VolunteerId, cancellationToken);
        if (volunteerResult.IsFailure)
        {
            return volunteerResult.Error;
        }

        var phone = PhoneNumber.Create(request.Dto.Phone).Value;

        var description = Description.Create(request.Dto.Description).Value;

        var email = Email.Create(request.Dto.Email).Value;

        var experienceYears = ExsperienceYears.Create(request.Dto.ExperienceYears).Value;
        
        volunteerResult.Value.UpdateMainInfo(phone, description, email, experienceYears);

        var result = await _volunteersRepository.Save(volunteerResult.Value, cancellationToken);
        
        _logger.LogInformation("Updated volunteer with Id {volunteerId}", request.VolunteerId);
        
        return result;
    }
}