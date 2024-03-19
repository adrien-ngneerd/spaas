using Ngneerd.PowerplantCodingChallenge.Domain.Entities.Fuels;
using Ngneerd.PowerplantCodingChallenge.Domain.Enums;

namespace Ngneerd.PowerplantCodingChallenge.Domain.Entities.Powerplants;

public class GasFired : EmittingPowerplant
{
    #region Properties

    #endregion

    #region Constructors

    public GasFired(Gas fuel, string name, decimal efficiency, long pMax, long pMin) : base(fuel, name, efficiency,
        pMax, pMin,
        PowerplantType.GasFired)
    {
    }

    #endregion

    #region Public Methods

    public override decimal CostPerMWh()
    {
        var baseCost = Fuel.Cost / Efficiency;
        return baseCost * (CarbonDioxidePerMwh * Fuel.CarbonDioxideEmissionCost);
    }

    #endregion
}