using CSharpFunctionalExtensions;
using FluentValidation.Results;
using HelpAnimal.API.Responce;
using HelpAnimal.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HelpAnimal.API.Extensions;

public static class ResponceExtensions
{
    public static ActionResult ToResponce(this Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Failure => StatusCodes.Status500InternalServerError,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        var responceError = new ResponceError(error.Code, error.Message, null);

        var envelope = Envelope.Error([responceError]);

        return new ObjectResult(envelope)
        {
            StatusCode = statusCode
        };
    }

    public static ActionResult ToValidationErrorResponce(this ValidationResult result)
    {
        if (result.IsValid)
            throw new InvalidOperationException("Result can not be succed");

        var validationErrors = result.Errors;

        var responceErrors = from validationError in validationErrors
            let errorMessage = validationError.ErrorMessage
            let error = Error.Deserialize(errorMessage)
            select new ResponceError(error.Code, error.Message, validationError.PropertyName);

        var envelope = Envelope.Error(responceErrors);

        return new ObjectResult(envelope)
        {
            StatusCode = StatusCodes.Status400BadRequest
        };
    }
}