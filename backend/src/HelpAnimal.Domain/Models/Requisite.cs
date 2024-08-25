namespace HelpAnimal.Domain.Models;
using HelpAnimal.Domain.ForAll;

public record Requisite
{
   private Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get;  } 
    public string Description { get;  } 
    
   
    public static Result<Requisite> Create (string title, string description)
    {
         if (string.IsNullOrWhiteSpace(title))
        {
            return "Title cannot be empty or whitespace.";
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            return "Description cannot be empty or whitespace.";
        }

        return new Requisite(title, description);

    }
}