using Zoo.Models;
using Xunit;

namespace TestZoo {
    public class habitTest {
        [Fact]
        public void CanIdentifyClimateType() {
            Enclosure enclosure = new() { Climate = Enclosure.ClimateType.Tropical };

            Assert.Equal(Enclosure.ClimateType.Tropical, enclosure.Climate);
        }

        [Fact]
        public void CanIdentifyHabitatType() {
            Enclosure enclosure = new() { Habitat = Enclosure.HabitatType.Forest };

            Assert.Equal(Enclosure.HabitatType.Forest, enclosure.Habitat);
        }
    }
}