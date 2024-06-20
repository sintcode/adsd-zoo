using Xunit;
using Zoo.Models;

namespace TestZoo {
    public class DatabaseTest {
        //Refuses to run, not sure why, no error though
        [Fact]
        public void CanAddAnimalToDatabase() 
        {
            // Arrange
            Database database = new();
            Animal animal = new() { Id = 1, Name = "Lion" };

            // Act
            database.AddAnimal(animal);

            // Assert
            Animal retrievedAnimal = database.GetAnimal(animal.Id);
            Assert.Equal(animal.Name, retrievedAnimal.Name);
        }
    }
}