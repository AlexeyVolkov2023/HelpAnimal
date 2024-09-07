namespace HelpAnimal.Application.DTOs;

public record CreateFullNameDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Patronymik { get; set; }
}