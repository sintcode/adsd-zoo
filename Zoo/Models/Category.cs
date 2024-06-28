using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Zoo.Models 
{
    public class Category 
    {
        //Primary Attributes
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [AllowNull]
        public string Description { get; set; } //Nullable, optional

        //List of all Species a Category contains
        [AllowNull]
        public List<Species> Species { get; set; } = [];

        //Zoo
        [ForeignKey("Zoo")]
        public int ZooId { get; set; }
        public ZooModel Zoo { get; set; }
    }
}
