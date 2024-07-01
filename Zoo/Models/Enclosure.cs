using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Zoo.Models 
{
    [Table("Enclosures")]
    public class Enclosure 
    {
        //Primary Attributes
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        //Size
        [Required]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
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
        public enum SecurityLevel {None, Low, Medium, High};
        [Required]
        public SecurityLevel SecurityRequired { get; set; }

        //List of all Animals the Enclosure contains
        [AllowNull]
        public List<Animal> Animals { get; set; } = [];

        //For knowing if an enclosure is meant for predators and what species as putting predators with prey or other species of predators is a very bad idea
        [Required]
        public bool PredatorEnclosure { get; set; }

        //Not just 'Species' as it's only relevant if Predators are in the enclosure, prey can live together (usually)
        [AllowNull]
        [ForeignKey("Species")]
        public int PredatorSpeciesId { get; set; } //Nullable
        [AllowNull]
        public Species PredatorSpecies { get; set; } //Nullable

        //Zoo
        [AllowNull]
        [ForeignKey("Zoo")]
        public int ZooId { get; set; }
        [AllowNull]
        public ZooModel Zoo { get; set; }
    }
}
