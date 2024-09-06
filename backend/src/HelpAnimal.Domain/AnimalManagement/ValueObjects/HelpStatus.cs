﻿using CSharpFunctionalExtensions;

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

    public static Result<HelpStatus> Create(string input)
    {
        var check = input.Trim().ToLower();

        if (!_all.Any(s => s.Value == check))
        {
            return Result.Failure<HelpStatus>(
                $"Invalid HelpStatus value: {check}." +
                $" Valid values are: {string.Join(", ", _all.Select(s => s.Value))}");
        }

        return Result.Success(new HelpStatus(check));
    }
}