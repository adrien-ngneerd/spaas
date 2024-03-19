namespace Ngneerd.PowerplantCodingChallenge.Domain.Entities.Fuels;

public class Gas : Fuel
{
    #region Properties

    public decimal CarbonDioxideEmissionCost { get; set; }

    #endregion

    #region Constructors

    public Gas(decimal cost, decimal? carbonDioxideEmissionCost = null)
    {
        Cost = cost;
        if (carbonDioxideEmissionCost != null)
            CarbonDioxideEmissionCost = carbonDioxideEmissionCost.Value;
    }

    #endregion
}