using System.Collections.Generic;
using System.Linq;
using Zoo.Data;

namespace Zoo.Models 
{
    public class Database 
    {
        private List<Animal> animals = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            Console.WriteLine($"Added animal: {animal.Name}");
        }

        public Animal GetAnimal(int id) {
            return animals.FirstOrDefault(a => a.Id == id);
        }
    }
}
