namespace Zoo.Models 
{
    public class Animal 
    {
        //Primary Attributes
        public int Id { get; set; }
        public string Name { get; set; }
        public enum Genders { Male, Female } //Could even be flags because it's 2024, who knows really.
        public Genders Gender { get; set; }
        public double Weight { get; set; }

        //Optional extra details about an Animal
        public string? Personality { get; set; } //Nullable, optional information
        public string? PreferredDiet { get; set; } //Nullable, optional information, consider this 'Prey' for predators

        //Species, not nullable as Animals ALWAYS have a species
        public int SpeciesId { get; set; }
        public Species Species { get; set; }

        //Zoo
        public int ZooId { get; set; }
        public ZooModel Zoo { get; set; }

        //Enclosure, nullable as assignment to Enclosure is not a guarantee
        public int? EnclosureId { get; set; }
        public Enclosure? Enclosure { get; set; }
    }
}
