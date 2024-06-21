using Zoo.Data;

namespace Zoo.Models {
    public class Database {
        public void AddAnimal(Animal animal) 
        {
            Species newSpecies = new()
            {
                Id = 1,
                Name = "Lion",
                LatinName = "Panthera Leo",
                Size = Species.SizeClass.Large,
                Diet = Species.DietType.Carnivore,
                Activity = Species.ActivityPattern.Diurnal,
                Predator = true,
                SpaceRequired = 50.0,
                SecurityRequired = Species.SecurityLevel.High
            };

            Animal newAnimal = new() 
            {
                Name = "Alex",
                SpeciesId = 1, //Using above-made 'Lion'
                EnclosureId = 1, // assuming an enclosure with Id 1 exists
            };
            
            Database db = new();
            db.AddAnimal(newAnimal);
        }

        public Animal GetAnimal(int id) {
            // Code to retrieve the animal from the database
            // For now, return a dummy animal
            return new Animal() { Id = id, Name = "Dummy" };
        }
    }
}
