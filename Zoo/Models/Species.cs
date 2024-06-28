using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Zoo.Models 
{
    public class Species 
    {
        //Primary Attributes
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } //Common Name, example: Grizzly Bear
        [Required]
        public string LatinName { get; set; } //Scientific Name, example: Ursus arctos horribilis

        //Size, includes Space Required
        public enum SizeClass {Microscopic, Tiny, Small, Medium, Large, Huge}; //Tiny = VerySmall and Huge = VeryLarge, renamed to avoid confusion
        [Required]
        public SizeClass Size { get; set; }
        [Required]
        public double SpaceRequired { get; set; }

        //Diet, includes whether or not the Species is predatory for safety checks later
        public enum DietType {Carnivore, Omnivore, Herbivore, Insectivore, Piscivore};
        [Required]
        public DietType Diet { get; set; }
        [Required]
        public bool Predator { get; set; }

        //Activity
        public enum ActivityPattern {Diurnal, Nocturnal, Cathmeral};
        [Required]
        public ActivityPattern Activity { get; set; }

        //Security
        public enum SecurityLevel {None, Low, Medium, High};
        [Required]
        public SecurityLevel SecurityRequired { get; set; }

        //Categories, made into List as a Species can potentionally be part of multiple categories, example: Quadraped, Mammal
        [AllowNull]
        public List<Category> Categories { get; set; } = [];

        //Animals, includes all animals belonging to a species, can include from multiple Zoos
        [AllowNull]
        public List<Animal> Animals { get; set; } = [];
    }
}
