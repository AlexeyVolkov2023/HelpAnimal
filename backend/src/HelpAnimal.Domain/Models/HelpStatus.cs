namespace HelpAnimal.Domain.Models;

public record HelpStatus
{
    private static readonly HelpStatus NeedsHelp = new(nameof(NeedsHelp));
    private static readonly HelpStatus LookingForHome = new(nameof(LookingForHome));
    private static readonly HelpStatus FoundHome = new(nameof(FoundHome));

    private static readonly HelpStatus[] _all = [NeedsHelp, LookingForHome, FoundHome];
    public string? Value { get; }

    public HelpStatus()
    {
        
    }

    private HelpStatus(string value) 
    {
        Value = value;
    }

    public static HelpStatus Create(string input)
    {
        var helpStatus = input.Trim().ToLower();

        return new HelpStatus(helpStatus);
    }
}