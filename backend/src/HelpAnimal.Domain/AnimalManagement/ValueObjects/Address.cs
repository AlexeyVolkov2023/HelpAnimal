
using CSharpFunctionalExtensions;
using HelpAnimal.Domain.Shared;

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


    public static Result<Address, Error> Create(
                                        string country,
                                        string city,
                                        string street,
                                        int numberHome)
    {
        if (string.IsNullOrWhiteSpace(country))
            return Errors.General.ValueIsInvalid("Country");
        
        if (string.IsNullOrWhiteSpace(city))
            return Errors.General.ValueIsInvalid("City");
        
        if (string.IsNullOrWhiteSpace(street))
            return Errors.General.ValueIsInvalid("Street");
        
        if (numberHome <= 0)
            return Errors.General.ValueIsInvalid( "NumberHome");

        return new Address(country, city, street, numberHome);
        
    }
}