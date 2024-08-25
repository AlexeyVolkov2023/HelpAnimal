using HelpAnimal.Domain.ForAll;

namespace HelpAnimal.Domain.Models;

public class Species : Entity<Speciesid>
{
    private Species(Speciesid id) : base(id)
    {
        
    }

    private Species(Speciesid id, string name, List<Breed> breeds) : base(id)
    {
        Name = name;
        Breeds = breeds;
    }

    public string Name { get;  } 
    
    public List<Breed>? Breeds { get; private set; } = []; 

    
    public static Result<Species> Create(Speciesid speciesid, string name, List<Breed> breeds)
    {
        return new Species(speciesid, name, breeds);
    }
}