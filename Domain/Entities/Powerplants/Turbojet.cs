using Ngneerd.PowerplantCodingChallenge.Domain.Entities.Fuels;
using Ngneerd.PowerplantCodingChallenge.Domain.Enums;

namespace Ngneerd.PowerplantCodingChallenge.Domain.Entities.Powerplants;

public class Turbojet : Powerplant<Kerosine>
{
    #region Constructors

    public Turbojet(Kerosine fuel, string name, decimal efficiency, long pMax, long pMin) : base(fuel, name, efficiency,
        pMax, pMin,
        PowerplantType.GasFired)
    {
    }

    #endregion
}