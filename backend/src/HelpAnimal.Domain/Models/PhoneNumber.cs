using System.Text.RegularExpressions;
using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public record PhoneNumber
{
   private PhoneNumber(string number)
    {
        Number = number;
    }
    public string Number { get; set; }



    public static Result<PhoneNumber> Create(string number)
    {
        const string PHONE_NUMBER_REGEX = @"^\+?\d{10,15}$"; 
        
        if (string.IsNullOrWhiteSpace(number))
        {
           return "Phone number cannot be empty or whitespace.";
        }
        if (!Regex.IsMatch(number, PHONE_NUMBER_REGEX))
        {
            throw new ArgumentException("Phone number is invalid. It should be 10-15 digits long, possibly with a '+' prefix.", nameof(number));
        }
        return new PhoneNumber(number);
    }
}