using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record HelpStatus
{
    private static readonly HelpStatus NeedsHelp = new(nameof(NeedsHelp));
    private static readonly HelpStatus LookingForHome = new(nameof(LookingForHome));
    private static readonly HelpStatus FoundHome = new(nameof(FoundHome));

    private static readonly HelpStatus[] _all = [NeedsHelp, LookingForHome, FoundHome];


    private HelpStatus(string value)
    {
        Value = value;
    }

    public string? Value { get; }

    public static Result<HelpStatus, Error> Create(string input)
    {
        var check = input.Trim().ToLower();

        if (!_all.Any(s => s.Value == check))
        {
            return Errors.General.ValueIsInvalid("HelpStatus");
        }

        return new HelpStatus(check);
    }
}