using NBomber.Contracts;
using NBomber.CSharp;
using Zoo.Models;
using Xunit;
using System;

namespace TestZoo
{ 
    public class AnimalLoadTest
    {
        [Fact]
        public void RunLoadTest()
        {
            Database database = new();
            Random random = new();

            IStep addAnimalStep = Step.Create("AddAnimal", async context =>
            {
                database.AddAnimal(new Animal { Id = random.Next(), Name = "Lion" });
                return Response.Ok("Animal added to database");
            });

            IStep getAnimalStep = Step.Create("GetAnimal", async context =>
            {
                return database.GetAnimal(random.Next()) != null ? Response.Ok("Animal successfully retrieved") : Response.Fail("Failed to retrieve Animal");
            });

            Scenario scenario = ScenarioBuilder
                .CreateScenario("Add and get animal", new[] { addAnimalStep, getAnimalStep })
                .WithLoadSimulations(Simulation.InjectPerSec(rate: 1000, during: TimeSpan.FromSeconds(5)));

            NBomberRunner.RegisterScenarios(scenario).Run();
        }
    }
}