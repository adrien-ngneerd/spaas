using Ngneerd.PowerplantCodingChallenge.Domain.Entities.Fuels;
using Ngneerd.PowerplantCodingChallenge.Domain.Enums;

namespace Ngneerd.PowerplantCodingChallenge.Domain.Entities;

public abstract class EmittingPowerplant : Powerplant<Gas>
{
    #region Properties

    // Tons of carbon dioxide generated of each MWh produced
    public decimal CarbonDioxidePerMwh { get; set; } = 0.03m;

    #endregion

    #region Constructors

    protected EmittingPowerplant(Gas fuel, string name, decimal efficiency, long pMax, long pMin, PowerplantType type)
        : base(fuel, name, efficiency, pMax, pMin, type)
    {
    }

    #endregion
}