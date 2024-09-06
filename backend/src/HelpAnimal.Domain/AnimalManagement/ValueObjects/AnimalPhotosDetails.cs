namespace HelpAnimal.Domain.AnimalManagement.ValueObjects;


public record AnimalPhotosDetails
{
   private AnimalPhotosDetails()
   {
   }

   public AnimalPhotosDetails(List<AnimalPhoto> photos)
   {
      Photos = photos;
   }

   public IReadOnlyList<AnimalPhoto> Photos { get; } 
}