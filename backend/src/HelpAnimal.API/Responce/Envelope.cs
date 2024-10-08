using HelpAnimal.Domain.Shared;

namespace HelpAnimal.API.Responce;

public record ResponceError(string? ErrorCode, string? ErrorMessage, string? InvalidField);

public record Envelope
{
    public object? Result { get; }
    public List<ResponceError> Errors { get; }
    public DateTime TimeGenerated { get; }

    private Envelope(object? result,IEnumerable<ResponceError>? errors)
    {
        Result = result;
        Errors = errors.ToList();
        TimeGenerated = DateTime.Now;
        
        
    }

    public static Envelope Ok(object? result  = null) =>
        new (result, []); 
    
    public static Envelope Error(IEnumerable<ResponceError> errors) =>
        new (null, errors);
    
}