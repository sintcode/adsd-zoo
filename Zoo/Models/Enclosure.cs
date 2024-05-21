namespace Zoo.Models {
    public class Enclosure {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Animal> Animals { get; set; } = new();
        public enum ClimateType {Tropical, Temperate, Arctic, Arid};
        public ClimateType Climate { get; set; }
        [Flags]
        public enum HabitatType {
            Forest = 1, 
            Aquatic = 2, 
            Desert = 4, 
            Grassland = 8,
            Tundra = 16
        };
        public bool PredatorEnclosure { get; set; }
        public bool PredatorSpecies { get; set; }
        public HabitatType Habitat { get; set; }
        public enum SecurityLevel {Low, Medium, High};
        public SecurityLevel SecurityRequired { get; set; }
        public double Size { get; set; }
    }
}
