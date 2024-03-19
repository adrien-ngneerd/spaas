using Ngneerd.PowerplantCodingChallenge.Domain.Entities.Fuels;
using Ngneerd.PowerplantCodingChallenge.Domain.Entities.Powerplants;

namespace Ngneerd.PowerplantCodingChallenge.Domain.Entities;

public class ProductionPlan
{
    #region Fields

    private readonly List<IPowerplant> _powerplants;
    private readonly long _load;

    #endregion

    #region Properties

    public Dictionary<IPowerplant, decimal?> RequiredPowerPerPowerplant = new();

    #endregion

    #region Constructors

    public ProductionPlan(long load, List<IPowerplant> powerplants)
    {
        _load = load;
        _powerplants = powerplants;
    }

    #endregion

    #region Public Methods

    public bool Generate()
    {
        if (_powerplants == null || !_powerplants.Any())
            throw new InvalidOperationException("Cannot generate production plan without powerplants");

        decimal currentLoad = 0;
        var orderedPowerplants = _powerplants.OrderBy(p => p.CostPerMWh());
        foreach (var powerplant in orderedPowerplants)
        {
            decimal requiredPower;
            if (currentLoad + powerplant.PMax > _load)
            {
                requiredPower = _load - currentLoad;
            }
            else
            {
                requiredPower = powerplant.PMax;
            }

            RequiredPowerPerPowerplant.Add(powerplant, requiredPower);
            currentLoad += requiredPower;
            if (currentLoad == _load)
                return true;
        }

        return false;
    }

    #endregion
}