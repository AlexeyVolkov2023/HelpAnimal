namespace HelpAnimal.Domain.Models;

public record Address
{
    public Address()
    {
    }

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
    public string Street { get;  }   
    public int NumberHome { get;  }
    

    public static Address Create(
        string country,
        string city, 
        string street,
        int numberHome)
    {
        return new Address(country, city, street, numberHome);
    }
}