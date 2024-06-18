namespace Zoo.Models 
{
    public class Enclosure 
    {
        //Primary Attributes
        public int Id { get; set; }
        public string Name { get; set; }

        //List of all Animals the Enclosure contains
        public List<Animal> Animals { get; set; } = []; 
        
        //Size
        public double Size { get; set; }

        //For knowing if an enclosure is meant for predators and what species as putting predators with prey or other species of predators is a very bad idea
        public bool PredatorEnclosure { get; set; }
        public int? PredatorSpeciesId { get; set; } //Nullable
        public Species? PredatorSpecies { get; set; } //Nullable

        //Climate & Habitat
        public enum ClimateType {Tropical, Temperate, Arctic, Arid, Rainforest};
        public ClimateType Climate { get; set; }
        [Flags]
        public enum HabitatType //Multiple types selectable thanks to [Flags]
        {
            Forest = 1, 
            Aquatic = 2, 
            Desert = 4, 
            Grassland = 8,
            Tundra = 16,
            Marsh = 32
        };
        public HabitatType Habitat { get; set; }

        //Security Level
        public enum SecurityLevel {Low, Medium, High};
        public SecurityLevel SecurityRequired { get; set; }

    }
}
