using Ngneerd.PowerplantCodingChallenge.Domain.Entities.Fuels;
using Ngneerd.PowerplantCodingChallenge.Domain.Enums;

namespace Ngneerd.PowerplantCodingChallenge.Domain.Entities;

public abstract class Powerplant<T> : IPowerplant where T : Fuel
{
    #region Properties

    public PowerplantType Type { get; set; }
    public T Fuel { get; set; }
    public string Name { get; set; }

    // Efficiency expressed in percentages
    public decimal Efficiency { get; set; }
    public decimal PMax { get; set; }
    public decimal PMin { get; set; }

    #endregion

    #region Constructors

    protected Powerplant()
    {
    }

    protected Powerplant(T fuel, string name, decimal efficiency, decimal pMax, decimal pMin,
        PowerplantType type) : this()
    {
        Fuel = fuel;
        Name = name;
        Type = type;
        Efficiency = efficiency;
        PMax = pMax;
        PMin = pMin;
    }

    #endregion

    #region Public Methods

    public virtual decimal CostPerMWh()
    {
        return Fuel.Cost / Efficiency;
    }

    #endregion
}