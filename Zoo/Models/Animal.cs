using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Zoo.Models 
{
    public class Animal 
    {
        //Primary Attributes
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public enum Genders { Male, Female } //Could even be flags because it's 2024, who knows really.
        [Required]
        public Genders Gender { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double Weight { get; set; }

        //Optional extra details about an Animal
        [AllowNull]
        public string Personality { get; set; } //Nullable, optional information
        [AllowNull]
        public List<string> PreferredDiet { get; set; } = [];//Nullable, optional information, consider this 'Prey' requirement for predators
        //You don't feed other Animals from the Zoo to eachother! A lion might eat (and prefer) zebra meat, but not a live one when living inside a zoo!
        //tl;dr Feeding live animals is pretty much illegal everywhere and very cruel, therefore 'PreferredDiet' instead of 'Prey'
        //Funny story though, looking up Animal APIs, a Koala has the Prey 'Eucalyptus Leaves', I guess some people would be happy to hear that

        //Species
        [AllowNull]
        [ForeignKey("Species")]
        public int SpeciesId { get; set; }
        [AllowNull]
        public Species Species { get; set; }

        //Zoo
        [AllowNull]
        [ForeignKey("Zoo")]
        public int ZooId { get; set; }
        [AllowNull]
        public ZooModel Zoo { get; set; }

        //Enclosure
        [AllowNull]
        [ForeignKey("Enclosure")]
        public int EnclosureId { get; set; }
        [AllowNull]
        public Enclosure Enclosure { get; set; }
    }
}
