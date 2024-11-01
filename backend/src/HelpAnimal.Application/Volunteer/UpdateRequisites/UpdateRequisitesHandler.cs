using CSharpFunctionalExtensions;
using HelpAnimal.Application.Volunteer.Dto;
using HelpAnimal.Domain.Shared;
using HelpAnimal.Domain.Shared.ValueObject;
using Microsoft.Extensions.Logging;

namespace HelpAnimal.Application.Volunteer.UpdateRequisites;

public class UpdateRequisitesHandler
{
    private readonly IVolunteersRepository _volunteersRepository;
    private readonly ILogger<UpdateRequisitesHandler> _logger;

    public UpdateRequisitesHandler (
        IVolunteersRepository volunteersRepository,
        ILogger<UpdateRequisitesHandler> logger)
    {
        _volunteersRepository = volunteersRepository;
        _logger = logger;
    }
    public async Task<Result<Guid, Error>> Handle(
        UpdateRequisitesRequest request,
        CancellationToken cancellationToken = default)
    {
        var volunteerResult = await _volunteersRepository.GetById(request.VolunteerId, cancellationToken);
        if (volunteerResult.IsFailure)
        {
            return volunteerResult.Error;
        }

        var requisites = request.Fto.Requisites
            .Select(r => Requisite.Create(r.Title, r.Description).Value);

        var requisitesDetails = new RequisiteDetails(requisites);
        
        volunteerResult.Value.UpdateRequisiteCollection(requisitesDetails);

        var result = await _volunteersRepository.Save(volunteerResult.Value, cancellationToken);
        
        _logger.LogInformation("Updated requisite for volunteer with Id {volunteerId}", request.VolunteerId);
        
        return result;
    }
}