using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public record SocialNetwork
{
    private SocialNetwork(string title, string link)
    {
        Title = title;
        Link = link;
    }

    public string? Title { get; }
    public string? Link { get; }

    public static Result<SocialNetwork> Create(string title, string link)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return "Title cannot be empty or whitespace.";
        }

        if (string.IsNullOrWhiteSpace(link))
        {
            throw new ArgumentException("Link cannot be empty or whitespace.", nameof(link));
        }
      
        if (!Uri.TryCreate(link, UriKind.Absolute, out _))
        {
            throw new ArgumentException("Invalid URL format.", nameof(link));
        }

        return new SocialNetwork(title, link);
    }
}