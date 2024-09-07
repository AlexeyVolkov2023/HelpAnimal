using CSharpFunctionalExtensions;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record SocialNetwork
{
    private SocialNetwork(string title, string link)
    {
        Title = title;
        Link = link;
    }

    public string Title { get; }
    public string Link { get; }

    public static Result<SocialNetwork> Create(string title, string link)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<SocialNetwork>("Title cannot be empty or whitespace.");
        }

        if (string.IsNullOrWhiteSpace(link))
        {
            return Result.Failure<SocialNetwork>("Link cannot be empty or whitespace.");
        }

        return Result.Success(new SocialNetwork(title, link));
    }
}