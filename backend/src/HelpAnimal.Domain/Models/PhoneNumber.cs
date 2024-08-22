namespace HelpAnimal.Domain.Models;

public record PhoneNumber
{
    private PhoneNumber()
    {
    }

    private PhoneNumber(string number)
    {
        Number = number;
    }
    public string Number { get; set; }



    public static PhoneNumber Create(string number)
    {
        return new PhoneNumber(number);
    }
}