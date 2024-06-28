using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Zoo.Models 
{
    public class ZooModel //Can't name model Zoo in namespace Zoo
    {
        //Primary Attributes
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //Secondary Attributes
        [AllowNull]
        public string Description { get; set; } //Description is optional
        [AllowNull]
        public string Country { get; set; } //Country is optional
        [AllowNull]
        public string City { get; set; } //City is optional

        //All Animals, Enclosures and Categories available in the Zoo, Species exist outside of Zoos
        [AllowNull]
        public List<Animal> Animals { get; set; } = [];
        [AllowNull]
        public List<Enclosure> Enclosures { get; set; } = [];
        [AllowNull]
        public List<Category> Categories { get; set; } = [];
    }
}
