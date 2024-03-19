using Ngneerd.PowerplantCodingChallenge.Domain.Entities.Fuels;
using Ngneerd.PowerplantCodingChallenge.Domain.Entities.Powerplants;
using Xunit;

namespace Domain.UnitTests.Entities;

public class PowerplantTests
{
    [Fact]
    public void When_EfficiencyAndCostAreSet_Should_Return_CostPerMwh()
    {
        var powerplant = new GasFired(new Gas(1, 0.3m), "test-powerplant", 0.6m, 100, 0);
        var cost = powerplant.CostPerMWh();
        Assert.Equal(0.015m, cost);
    }
}