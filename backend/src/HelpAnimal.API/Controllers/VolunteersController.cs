using HelpAnimal.API.Extensions;
using HelpAnimal.Application.Volunteer.CreateVolunteer;
using Microsoft.AspNetCore.Mvc;

namespace HelpAnimal.API.Controllers;


public class VolunteersController : ApplicationController
{
    [HttpPost]

    public async Task<IActionResult> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
        {
            return result.Error.ToResponce();
        }

        return Ok(result.Value);
    }
}