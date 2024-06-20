namespace Zoo.Models 
{
    public class ZooModel //Can't name model Zoo in namespace Zoo
    {
        //Primary Attributes
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } //Description is optional
        public string? Country { get; set; } //Country is optional
        public string? City { get; set; } //City is optional

        //All Animals, Enclosures and Categories available in the Zoo, Species exist outside of Zoos
        public List<Animal> Animals { get; set; } = [];
        public List<Enclosure> Enclosures { get; set; } = [];
        public List<Category> Categories { get; set; } = [];
    }
}
