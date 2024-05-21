using Zoo.Models;

namespace TestZoo {
    public class AnimalTest {
        [Fact]
        public void CheckIfCarnivore() {
            Animal dog = new();
            dog.Diet = Animal.DietType.Carnivore;
            Assert.Equivalent(dog.Diet, Animal.DietType.Carnivore);
        }
    }
}