namespace Zoo.Models {
    public class Animal {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public enum SizeClass {Microscopic, Tiny, Small, Medium, Large, Huge};
        public SizeClass Size { get; set; }
        public enum DietType {Carnivore, Omnivore, Herbivore, Insectivore, Piscivore};
        public DietType Diet { get; set; }
        public enum ActivityPattern {Diurnal, Nocturnal, Cathmeral};
        public ActivityPattern Activity { get; set; }
        public bool Predator { get; set; }
        public double SpaceRequired { get; set; }
        public enum SecurityLevel {None, Low, Medium, High}
        public SecurityLevel SecurityRequired { get; set; }

        public int CategoryId { get; set; }
        public int EnclosureId { get; set; }
    }
}
