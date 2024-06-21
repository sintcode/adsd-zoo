using NBomber.Contracts;
using NBomber.CSharp;

namespace TestZoo
{
    public class IndexStressTest 
    {
        [Fact]
        public void RunStressTest()
        {
            IStep getIndex = Step.Create("Get Index", async context => { 
                //Retrieve Index
                HttpResponseMessage response = await new HttpClient().GetAsync("http://localhost/7011/");

                //Return Result
                return response.IsSuccessStatusCode ? Response.Ok("Index retrieved successfully") : Response.Fail($"Failed to retrieve index, Status Code: {response.StatusCode}");
            });

            Scenario testIndex = ScenarioBuilder
                .CreateScenario("Get Index Scenario", getIndex)
                .WithLoadSimulations(Simulation.RampPerSec(1, TimeSpan.FromMinutes(5)));

            NBomberRunner.RegisterScenarios(testIndex).Run();
        }
    }
}