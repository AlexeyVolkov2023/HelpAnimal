namespace HelpAnimal.Domain.Models;

public record Requisite
{
    public Requisite()
    {
        
    }
    private Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get;  } = default!; // Название реквизита
    public string Description { get;  } = default!;// Описание, как сделать перевод
    
   
    public static Requisite Create (string requisite, string description)
    {
        return new Requisite(requisite, description);

    }
}