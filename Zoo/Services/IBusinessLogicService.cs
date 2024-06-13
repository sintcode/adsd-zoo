using Zoo.Models;
// In IBusinessLogicService.cs
namespace Zoo.Services
{
    public interface IBusinessLogicService
    {
        bool CanAddAnimalToEnclosure(Animal animal, Enclosure enclosure);
        // Voeg hier andere methoden toe die uw bedrijfslogica definiëren...
    }
}