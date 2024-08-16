using System.ComponentModel.DataAnnotations.Schema;

namespace HelpAnimal.Domain.Models;


public class AnimalPhotosDetails 
{
   public List<AnimalPhoto> Photos { get; private set; }  
}