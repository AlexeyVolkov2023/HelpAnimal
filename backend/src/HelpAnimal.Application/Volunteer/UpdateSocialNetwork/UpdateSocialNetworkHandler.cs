using CSharpFunctionalExtensions;
using HelpAnimal.Domain.AnimalManagement.ValueObjects;
using HelpAnimal.Domain.AnimalManagement.ValueObjects.ID;
using HelpAnimal.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace HelpAnimal.Application.Volunteer.UpdateSocialNetwork;

public class UpdateSocialNetworkHandler
{
    private readonly IVolunteersRepository _volunteersRepository;
    private readonly ILogger<UpdateSocialNetworkHandler> _logger;

    public UpdateSocialNetworkHandler(
        IVolunteersRepository volunteersRepository,
        ILogger<UpdateSocialNetworkHandler> logger)
    {
        _volunteersRepository = volunteersRepository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        UpdateSocialNetworkRequest request,
        CancellationToken cancellationToken = default)
    {
        var volunteerResult = await _volunteersRepository.GetById(request.VolunteerId, cancellationToken);
        if (volunteerResult.IsFailure)
        {
            return volunteerResult.Error;
        }

        var networks = request.Networks.SocialLinks
            .Select(r => SocialNetwork.Create(r.Network, r.Link).Value);

        var networksList = new SocialDetails(networks);

        volunteerResult.Value.UpdateSocialNetworks(networksList);

        var result = await _volunteersRepository.Save(volunteerResult.Value, cancellationToken);

        _logger.LogInformation("Updated social network for volunteer with Id {volunteerId}", request.VolunteerId);

        return result;
    }
}