namespace Zoo.Models 
{
    public class Category 
    {
        //Primary Attributes
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } //Nullable, optional

        //List of all Species a Category contains
        public List<Species> Species { get; set; } = [];

        //Zoo
        public int ZooId { get; set; }
        public ZooModel Zoo { get; set; }
    }
}
