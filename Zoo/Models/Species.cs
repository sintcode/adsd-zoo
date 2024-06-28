namespace Zoo.Models 
{
    public class Species 
    {
        //Primary Attributes
        public int Id { get; set; }
        public string Name { get; set; } //Common Name, example: Grizzly Bear
        public string LatinName { get; set; } //Scientific Name, example: Ursus arctos horribilis

        //Size, includes Space Required
        public enum SizeClass {Microscopic, Tiny, Small, Medium, Large, Huge};
        public SizeClass Size { get; set; }
        public double SpaceRequired { get; set; }

        //Diet, includes whether or not the Species is predatory for safety checks later
        public enum DietType {Carnivore, Omnivore, Herbivore, Insectivore, Piscivore};
        public DietType Diet { get; set; }
        public bool Predator { get; set; }

        //Activity
        public enum ActivityPattern {Diurnal, Nocturnal, Cathmeral};
        public ActivityPattern Activity { get; set; }

        //Security
        public enum SecurityLevel {None, Low, Medium, High};
        public SecurityLevel SecurityRequired { get; set; }

        //Categories, made into List as a Species can potentionally be part of multiple categories, example: Quadraped, Mammal
        public List<Category> Categories { get; set; } = [];

        //Animals, includes all animals belonging to a species, can include from multiple Zoos
        public List<Animal> Animals { get; set; } = [];
    }
}
