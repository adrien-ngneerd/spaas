using Ngneerd.PowerplantCodingChallenge.Domain.Entities.Fuels;
using Ngneerd.PowerplantCodingChallenge.Domain.Enums;

namespace Ngneerd.PowerplantCodingChallenge.Domain.Entities.Powerplants;

public class WindTurbine : Powerplant<Wind>
{
    #region Constructors

    public WindTurbine(Wind fuel, string name, decimal efficiency, long pMax, long pMin) : base(fuel, name, efficiency,
        pMax,
        pMin,
        PowerplantType.GasFired)
    {
        Efficiency = fuel.Quantity / 100;
        PMax = pMax * Efficiency;
    }

    #endregion

    #region Public Methods

    public override decimal CostPerMWh()
    {
        return 0;
    }

    #endregion
}