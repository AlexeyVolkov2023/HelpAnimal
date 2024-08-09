namespace HelpAnimal.Domain.Models;

public class HelpDetails
{
    public string Requisite { get; set; } // Название реквизита
    public string Description { get; set; } // Описание, как сделать перевод
    
    public HelpDetails(string requisite, string description)
    {
        Requisite = requisite;
        Description = description;
    }
}