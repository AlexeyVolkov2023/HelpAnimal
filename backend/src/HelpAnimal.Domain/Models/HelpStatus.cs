using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public record HelpStatus
{
    private static readonly HelpStatus NeedsHelp = new(nameof(NeedsHelp));
    private static readonly HelpStatus LookingForHome = new(nameof(LookingForHome));
    private static readonly HelpStatus FoundHome = new(nameof(FoundHome));

    private static readonly HelpStatus[] _all = [NeedsHelp, LookingForHome, FoundHome];
    public string? Value { get; }

    private HelpStatus(string value) 
    {
        Value = value;
    }

    public static Result<HelpStatus> Create(string input)
    {
        var check = input.Trim().ToLower();
        
        if (!_all.Any(s => s.Value == check))
        {
            return $"Invalid HelpStatus value: {check}." +
                    $" Valid values are: {string.Join(", ", _all.Select(s => s.Value))}";
        }

        return new HelpStatus(check);

        
    }
}