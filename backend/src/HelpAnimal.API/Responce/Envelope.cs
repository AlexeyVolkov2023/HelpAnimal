using HelpAnimal.Domain.Shared;

namespace HelpAnimal.API.Responce;

public record Envelope
{
    public object? Result { get; }
    public string? Code { get; }
    public string? Message { get; }
    public DateTime TimeGenerated { get; }

    private Envelope(object? result,Error? error)
    {
        Result = result;
        Code = error?.Code;
        Message = error?.Message;
        TimeGenerated = DateTime.Now;
    }

    public static Envelope Ok(object? result  = null) =>
        new (result, null); 
    
    public static Envelope Error(Error error) =>
        new (null, error);
    
}