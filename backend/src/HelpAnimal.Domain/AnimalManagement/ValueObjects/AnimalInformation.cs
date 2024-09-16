using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record AnimalInformation
{
    public AnimalInformation(
        string color,
        string healthInfo,
        double weight,
        double height,
        bool isNeutered)
    {
        Color = color;
        HealthInfo = healthInfo;
        Weight = weight;
        Height = height;
        IsNeutered = isNeutered;
    }

    public string Color { get; }
    public string HealthInfo { get; }
    public double Weight { get; }
    public double Height { get; }
    public bool IsNeutered { get; }

    public static Result<AnimalInformation, Error> Create(
        string color,
        string healthInfo,
        double weight,
        double height,
        bool isNeutered
    )
    {
        if (string.IsNullOrWhiteSpace(color))
        {
            return Errors.General.ValueIsInvalid("Color");
        }

        if (string.IsNullOrWhiteSpace(healthInfo))
        {
            return Errors.General.ValueIsInvalid("Health");
        }

        if (weight <= 0)
        {
            return Errors.General.ValueIsInvalid("Weight");
        }

        if (height <= 0)
        {
            return Errors.General.ValueIsInvalid("Height");
        }

        return new AnimalInformation(color, healthInfo, weight, height, isNeutered);
    }
}