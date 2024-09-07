using CSharpFunctionalExtensions;
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

        var envelope = Envelope.Error(error);
        
        return new ObjectResult(envelope)
        {
            StatusCode = statusCode
        };
    } 
     public static ActionResult<T> ToResponce<T>(this Result<T, Error> result)
     {
         if (result.IsSuccess)
             return new OkObjectResult(result.Value);
         
        var statusCode = result.Error.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Failure => StatusCodes.Status500InternalServerError,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        var envelope = Envelope.Error(result.Error);
        
        return new ObjectResult(envelope)
        {
            StatusCode = statusCode
        };
    } 
    
   
}