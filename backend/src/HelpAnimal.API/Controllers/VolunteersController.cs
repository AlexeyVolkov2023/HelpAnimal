using FluentValidation;
using HelpAnimal.API.Extensions;
using HelpAnimal.Application.Volunteer.Create;
using HelpAnimal.Application.Volunteer.Delete;
using HelpAnimal.Application.Volunteer.Dto;
using HelpAnimal.Application.Volunteer.UpdateMainInfo;
using HelpAnimal.Application.Volunteer.UpdateRequisites;
using HelpAnimal.Application.Volunteer.UpdateSocialNetwork;
using Microsoft.AspNetCore.Mvc;

namespace HelpAnimal.API.Controllers;

public class VolunteersController : ApplicationController
{
    [HttpPost]
    public async Task<ActionResult> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponce();


        return Ok(result.Value);
    }
    
    [HttpPatch("{id:guid}/social-network")]
    public async Task<ActionResult> UpdateSocialNetwork(
        [FromRoute] Guid id,
        [FromServices] UpdateSocialNetworkHandler handler,
        [FromBody] UpdateSocialNetworkFto fto ,
        [FromServices] IValidator<UpdateSocialNetworkRequest> validator,
        CancellationToken cancellationToken = default)
    {
        var request = new UpdateSocialNetworkRequest(id, fto);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid == false)
        {
            return validationResult.ToValidationErrorResponce();
        }

        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponce();

        return Ok(result.Value);
    }

    [HttpPatch("{id:guid}/main-info")]
    public async Task<ActionResult> UpdateMainInfo(
        [FromRoute] Guid id,
        [FromServices] UpdateMainInfoHandler handler,
        [FromBody] UpdateMainInfoDto dto,
        [FromServices] IValidator<UpdateMainInfoRequest> validator,
        CancellationToken cancellationToken = default)
    {
        var request = new UpdateMainInfoRequest(id, dto);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid == false)
        {
            return validationResult.ToValidationErrorResponce();
        }

        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponce();

        return Ok(result.Value);
    }
    
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid id,
        [FromServices] DeleteVolunteerHandler handler,
        [FromServices] IValidator<DeleteVolunteerRequest> validator,
        CancellationToken cancellationToken = default)
    {
        var request = new DeleteVolunteerRequest(id);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid == false)
        {
            return validationResult.ToValidationErrorResponce();
        }

        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponce();

        return Ok(result.Value);
    }
    
    [HttpPatch("{id:guid}/requisites")]
    public async Task<ActionResult> Updaterequisites(
        [FromRoute] Guid id,
        [FromServices] UpdateRequisitesHandler handler,
        [FromBody] UpdateRequisitesFto fto,
        [FromServices] IValidator<UpdateRequisitesRequest> validator,
        CancellationToken cancellationToken = default)
    {
        var request = new UpdateRequisitesRequest(id, fto);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid == false)
        {
            return validationResult.ToValidationErrorResponce();
        }

        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponce();

        return Ok(result.Value);
    }

    
    
}