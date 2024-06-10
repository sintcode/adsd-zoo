using Zoo.Models;
using Xunit;

namespace TestZoo {
    public class removeAnimal
    {

        [Fact]
        public void CanRemoveAnimal()
        {
            Enclosure enclosure = new();
            Animal animal = new() { Id = 1, Name = "Lion" };
            enclosure.Animals.Add(animal);
            enclosure.Animals.Remove(animal);

            Assert.DoesNotContain(animal, enclosure.Animals);
        }
    }
}