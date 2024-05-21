using Zoo.Models;

namespace TestZoo {
    public class EnclosureTest {

        [Fact]
        public void CheckIfTropical() {
            Enclosure rainForest = new();
            rainForest.Climate = Enclosure.ClimateType.Tropical;
            Assert.Equivalent(rainForest.Climate, Enclosure.ClimateType.Tropical);
        }

        [Fact]
        public void CheckIfArcticDesertContainsPenguin(){
            Enclosure arcticDesert = new();
            arcticDesert.Climate = Enclosure.ClimateType.Arctic;
            arcticDesert.Habitat = Enclosure.HabitatType.Desert;
            Animal penguin = new(){
                Id = 1, 
                Name = "Jeff",
                Species = "Emperor Penguin",
                Size = Animal.SizeClass.Medium,
                Diet = Animal.DietType.Piscivore,
                Activity = Animal.ActivityPattern.Cathmeral,
                Predator = true,
                SpaceRequired = 5.0,
                SecurityRequired = Animal.SecurityLevel.Low,
                CategoryId = 1,
                EnclosureId = 1
            };
            arcticDesert.Animals.Add(penguin);
            Assert.Equivalent(arcticDesert.Climate, Enclosure.ClimateType.Arctic);
            Assert.Equivalent(arcticDesert.Habitat, Enclosure.HabitatType.Desert);
            Assert.Contains(penguin, arcticDesert.Animals);
        }
    }
}