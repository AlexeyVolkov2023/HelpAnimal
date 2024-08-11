namespace HelpAnimal.Domain.Models;

public class HelpDetails
{
    public string Requisite { get; set; } // Название реквизита
    public string Description { get; set; } // Описание, как сделать перевод
    
    public static HelpDetails Create (string requisite, string description)
    {
        return new HelpDetails()
        {
            Requisite = requisite,
            Description = description,
        };
    }
}