using Zoo.Models;

namespace TestZoo {
    public class AnimalTest {
        [Fact]
        public void CheckIfCarnivore() {
            Animal dog = new();
            Species germanShepard = new(){Id = 1, Diet = Species.DietType.Carnivore};
            dog.SpeciesId = 1;
            Assert.Equivalent(dog.Species.Diet, Species.DietType.Carnivore);
        }
    }
}