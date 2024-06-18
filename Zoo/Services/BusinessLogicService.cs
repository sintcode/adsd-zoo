// In BusinessLogicService.cs
using Zoo.Models;

namespace Zoo.Services
{
    public class BusinessLogicService : IBusinessLogicService
    {
        public bool CanAddAnimalToEnclosure(Animal animal, Enclosure enclosure)
        {
            // Implementeer hier de logica om te bepalen of een dier aan een verblijf kan worden toegevoegd...
            return enclosure.Animals.Count < 5;
        }

        // Implementeer hier andere methoden die uw bedrijfslogica definiëren...
    }
}