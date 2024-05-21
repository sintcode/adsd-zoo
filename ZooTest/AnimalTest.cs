namespace ZooTest {
    public class AnimalTest {
        [Fact] 
        public void CheckIfMeatEater() {
            Animal Dog = new();
            Dog.Diet = Carnivore;
            Assert.AreEqual(Dog.Diet, Carnivore);
        }
    }
}