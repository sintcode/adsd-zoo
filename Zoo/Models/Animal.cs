﻿using System.ComponentModel.DataAnnotations;
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
        public double Weight { get; set; }

        //Optional extra details about an Animal
        [AllowNull]
        public string Personality { get; set; } //Nullable, optional information
        [AllowNull]
        public List<string> PreferredDiet { get; set; } = [];//Nullable, optional information, consider this 'Prey' for predators
        //Fun story, looking up Animal APIs, a Koala has the Prey 'Eucalyptus Leaves', I guess some people would be happy to hear that

        //Species, not nullable as Animals ALWAYS have a species
        [ForeignKey("Species")]
        public int SpeciesId { get; set; }
        public Species Species { get; set; }

        //Zoo
        [ForeignKey("Zoo")]
        public int ZooId { get; set; }
        public ZooModel Zoo { get; set; }

        //Enclosure, nullable as assignment to Enclosure is not a guarantee
        [AllowNull]
        [ForeignKey("Enclosure")]
        public int EnclosureId { get; set; }
        public Enclosure Enclosure { get; set; }
    }
}
