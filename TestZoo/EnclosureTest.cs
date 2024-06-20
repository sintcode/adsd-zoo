using Zoo.Models;

namespace TestZoo {
    public class EnclosureTest {

        [Fact]
        public void CheckIfTropical() 
        {
            Enclosure rainForest = new();
            rainForest.Climate = Enclosure.ClimateType.Tropical;
            Assert.Equivalent(rainForest.Climate, Enclosure.ClimateType.Tropical);
        }

        [Fact]
        public void CheckSecurityLevel()
        {
            Enclosure highSecurity = new();
            highSecurity.SecurityRequired = Enclosure.SecurityLevel.High;
            Assert.Equivalent(highSecurity.SecurityRequired,Enclosure.SecurityLevel.High);
        }

        [Fact]
        public void CheckIfArcticDesertContainsPenguin()
        {
            Enclosure arcticDesert = new(){Climate = Enclosure.ClimateType.Arctic, Habitat = Enclosure.HabitatType.Desert};
            Species emperorPenguin = new(){Id = 1, Name = "Emperor Penguin"};
            Animal penguin = new(){Name = "Jeff", Species = emperorPenguin};
            arcticDesert.Animals.Add(penguin);
            Assert.Equivalent(arcticDesert.Climate, Enclosure.ClimateType.Arctic);
            Assert.Equivalent(arcticDesert.Habitat, Enclosure.HabitatType.Desert);
            Assert.Contains(penguin, arcticDesert.Animals);
        }
    }
}