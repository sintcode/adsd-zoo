using Xunit;
using Zoo.Models;

namespace TestZoo {
    public class DatabaseTest {
        [Fact]
        public void CanAddAnimalToDatabase() {
            // Arrange
            Database database = new Database();
            Animal animal = new() { Id = 1, Name = "Lion" };

            // Act
            database.AddAnimal(animal);

            // Assert
            Animal retrievedAnimal = database.GetAnimal(animal.Id);
            Assert.Equal(animal.Name, retrievedAnimal.Name);
        }
    }
}