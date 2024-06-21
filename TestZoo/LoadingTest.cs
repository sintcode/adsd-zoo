using NBomber.Contracts;
using NBomber.CSharp;
using Zoo.Models;
using Xunit;
using System;

public class LoadTest
{
    [Fact]
    public void RunLoadTest()
    {
        var database = new Database();
        var random = new Random();

        var addAnimalStep = Step.Create("AddAnimal", async context =>
        {
            var animal = new Animal { Id = random.Next(), Name = "Lion" };
            database.AddAnimal(animal);
            return Response.Ok();
        });

        var getAnimalStep = Step.Create("GetAnimal", async context =>
        {
            var animal = database.GetAnimal(random.Next());
            return animal != null ? Response.Ok() : Response.Fail();
        });

        var scenario = ScenarioBuilder
            .CreateScenario("Add and get animal", new[] { addAnimalStep, getAnimalStep })
            .WithLoadSimulations(
                Simulation.InjectPerSec(rate: 1000, during: TimeSpan.FromSeconds(5))
            );

        NBomberRunner
            .RegisterScenarios(scenario)
            .Run();
    }
}