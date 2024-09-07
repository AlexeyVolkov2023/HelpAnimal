
using CSharpFunctionalExtensions;

namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;

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
            return Result.Failure<Address>("Country cannot be null or empty.");
        
        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>("City cannot be null or empty.");
        
        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>("Street cannot be null or empty.");
        
        if (numberHome <= 0)
            return Result.Failure<Address>( "NumberHome must be a positive integer.");

        return Result.Success(new Address(country, city, street, numberHome));
        
    }
}