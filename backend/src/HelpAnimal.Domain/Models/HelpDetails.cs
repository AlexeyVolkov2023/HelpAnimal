namespace HelpAnimal.Domain.Models;

public class HelpDetails
{
    private HelpDetails(string requisite, string description)
    {
        Requisite = requisite;
        Description = description;
    }

    public string Requisite { get; set; } = default!; // Название реквизита
    public string Description { get; set; } = default!;// Описание, как сделать перевод
    
    public static HelpDetails Create (string requisite, string description)
    {
        return new HelpDetails(requisite, description);

    }
}