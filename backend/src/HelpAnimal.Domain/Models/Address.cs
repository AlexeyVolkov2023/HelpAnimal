
using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public record Address
{
    private Address(
        string country,
        string city,
        string street,
        int numberHome)
    {
        Country = country;
        City = city;
        Street = street;
        NumberHome = numberHome;
    }

    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public int NumberHome { get; }


    public static Result<Address> Create(
        string country,
        string city,
        string street,
        int numberHome)
    {
        if (string.IsNullOrWhiteSpace(country))
           return "Country cannot be null or empty.";

        if (string.IsNullOrWhiteSpace(city))
            return"City cannot be null or empty.";

        if (string.IsNullOrWhiteSpace(street))
            return "Street cannot be null or empty.";

        if (numberHome <= 0)
            return "NumberHome must be a positive integer.";

        return new Address(country, city, street, numberHome);
        
    }
}