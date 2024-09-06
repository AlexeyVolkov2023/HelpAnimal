using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record ExsperienceYears
{
    private ExsperienceYears(int experienceYears)
    {
        ExperienceYears = experienceYears;
    }
    public int ExperienceYears { get; }

    public static Result<ExsperienceYears, Error> Create(int experienceYears)
    {
        if (experienceYears is > Constants.MAX_EXPERIENCE_YEARS or < 0)
        {
            return Errors.General.ValueIsInvalid("Experience Years");
        }

        return new ExsperienceYears(experienceYears);
    }
}

