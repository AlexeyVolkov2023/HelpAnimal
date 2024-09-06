using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

public record SocialNetwork
{
    private const string REGEX_FOR_URL = @"^(https?:\/\/)?([\da-z.-]+)\.([a-z.]{2,6})([\/\w .-]*)*\/?$";
    private SocialNetwork(string network, string link)
    {
        Network = network;
        Link = link;
    }

    public string Network { get; }
    public string Link { get; }

    public static Result<SocialNetwork, Error> Create(string network, string link)
    {
        if (string.IsNullOrWhiteSpace(network))
        {
            return Errors.General.ValueIsInvalid("Network");
        }

        if (string.IsNullOrWhiteSpace(link))
        {
            return Errors.General.ValueIsInvalid("Link");
        }
        
        if (!Regex.IsMatch(link, REGEX_FOR_URL))
        {
            return Errors.General.ValueIsInvalid("Link");
        }

        return new SocialNetwork(network, link);
    }
}