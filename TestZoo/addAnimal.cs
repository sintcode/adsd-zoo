using Zoo.Models;
using Xunit;

namespace TestZoo {
    public class addAnimal {

        [Fact]
        public void CanAddAnimal() {
            Enclosure enclosure = new();
            Animal animal = new() { Id = 1, Name = "Lion" };
            enclosure.Animals.Add(animal);

            Assert.Contains(animal, enclosure.Animals);
        }
    }
}