namespace HelpAnimal.Domain.Models;

public class HelpDetail
{
    private HelpDetail(string requisite, string description)
    {
        Requisite = requisite;
        Description = description;
    }

    public Guid Id { get; private set; }
    public string Requisite { get; set; } = default!; // Название реквизита
    public string Description { get; set; } = default!;// Описание, как сделать перевод
    
    public static HelpDetail Create (string requisite, string description)
    {
        return new HelpDetail(requisite, description);

    }
}