using Zoo.Models;

namespace TestZoo {
    public class CreateAnimalTest {
        [Fact]
        public void CheckIfCarnivore() {
            Species germanShepard = new(){Diet = Species.DietType.Carnivore};
            Animal dog = new(){Species = germanShepard};
            Assert.Equivalent(dog.Species.Diet, Species.DietType.Carnivore);
        }
    }
}