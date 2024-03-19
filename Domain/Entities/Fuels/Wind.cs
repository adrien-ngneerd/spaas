namespace Ngneerd.PowerplantCodingChallenge.Domain.Entities.Fuels;

public class Wind : Fuel
{
    #region Properties

    public decimal Quantity { get; set; }

    #endregion

    #region Constructors

    public Wind(long quantity)
    {
        Cost = 0;
        Quantity = quantity;
    }

    #endregion
}