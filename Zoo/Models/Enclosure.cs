using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Zoo.Models 
{
    [Table("Enclosures")]
    public class Enclosure 
    {
        //Primary Attributes
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        //Size
        [Required]
        public double Size { get; set; }

        //Climate & Habitat
        public enum ClimateType {Tropical, Temperate, Arctic, Arid, Rainforest};
        [Required]
        public ClimateType Climate { get; set; }

        [Flags]
        public enum HabitatType //Multiple types selectable thanks to [Flags]
        {
            Forest = 1, 
            Aquatic = 2, 
            Desert = 4, 
            Grassland = 8,
            Tundra = 16,
            Marsh = 32,
            Steppe = 64
        };
        [Required]
        public HabitatType Habitat { get; set; }

        //Security Level
        public enum SecurityLevel {Low, Medium, High};
        [Required]
        public SecurityLevel SecurityRequired { get; set; }

        //Collection of all Animals the Enclosure contains
        public ICollection<Animal> Animals { get; set; } = []; 

        //For knowing if an enclosure is meant for predators and what species as putting predators with prey or other species of predators is a very bad idea
        [Required]
        public bool PredatorEnclosure { get; set; }

        [AllowNull]
        [ForeignKey("PredatorSpecies")]
        public int? PredatorSpeciesId { get; set; } //Nullable
        public Species PredatorSpecies { get; set; } //Nullable

        //Zoo
        [ForeignKey("Zoo")]
        public int? ZooId { get; set; }
        public ZooModel Zoo { get; set; }
    }
}
