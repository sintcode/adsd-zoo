using Zoo.Data;

namespace Zoo.Models {
    public class Database {
        public void AddAnimal(Animal animal) {
            Animal newAnimal = new Animal() {
                Name = "Lion",
                Species = "Panthera leo",
                Size = Animal.SizeClass.Large,
                Diet = Animal.DietType.Carnivore,
                Activity = Animal.ActivityPattern.Diurnal,
                Predator = true,
                SpaceRequired = 50.0,
                SecurityRequired = Animal.SecurityLevel.High,
                EnclosureId = 1, // assuming an enclosure with Id 1 exists
                CategoryId = 1 // assuming a category with Id 1 exists
            };
            
            Database db = new Database();
            db.AddAnimal(newAnimal);
        }

        public Animal GetAnimal(int id) {
            // Code to retrieve the animal from the database
            // For now, return a dummy animal
            return new Animal() { Id = id, Name = "Dummy" };
        }
    }
}