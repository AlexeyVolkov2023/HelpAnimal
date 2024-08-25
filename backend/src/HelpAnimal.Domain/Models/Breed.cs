using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public class Breed : Entity<Breedid>
{
    private Breed(Breedid id) : base(id)
    {
    }
    private Breed(Breedid breedid, string title) : base(breedid)
    {
        Title = title;
    }
    public string Title { get;  } 
    
    public static Result<Breed> Create(Breedid breedid, string title)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > Constants.LOW_TEXT_LENGTH)
        {
            return "Title cannot be empty or whitespace.";
        }
        return new Breed(breedid, title);
    }
   
}