namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;


public record AnimalPhotosDetails
{
   private AnimalPhotosDetails()
   {
   }

   public AnimalPhotosDetails(IEnumerable<AnimalPhoto> photos)
   {
      Photos = photos.ToList();
   }

   public IReadOnlyList<AnimalPhoto> Photos { get; } 
}