using CSharpFunctionalExtensions;

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

    public static Result<AnimalInformation> Create(
        string color,
        string healthInfo,
        double weight,
        double height,
        bool isNeutered
    )
    {
        if (string.IsNullOrWhiteSpace(color))
        {
            return Result.Failure<AnimalInformation>("Color cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(healthInfo))
        {
            return Result.Failure<AnimalInformation>("Health information cannot be empty.");
        }

        if (weight <= 0)
        {
            return Result.Failure<AnimalInformation>("Weight must be greater than zero.");
        }

        if (height <= 0)
        {
            return Result.Failure<AnimalInformation>("Height must be greater than zero.");
        }

        return Result.Success(new AnimalInformation(color, healthInfo, weight, height, isNeutered));
    }
}