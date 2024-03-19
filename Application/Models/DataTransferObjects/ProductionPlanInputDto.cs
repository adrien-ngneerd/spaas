using System.Text.Json.Serialization;

namespace Ngneerd.PowerplantCodingChallenge.Application.Models.DataTransferObjects;

public class ProductionPlanInputDto
{
    public int Load { get; set; }
    [JsonPropertyName("fuels")] public FuelPricesDto FuelsPrices { get; set; }
    public PowerplantDto[] Powerplants { get; set; }
}

public class FuelPricesDto
{
    // Could be made more generic with a unit parsing
    // It would allow to set max quantities for other fuels than Wind, maybe Solar ?
    // Trying to aim for YAGNI and therefore choosing the straightforward approach
    [JsonPropertyName("gas(euro/MWh)")] public decimal Gas { get; set; }

    [JsonPropertyName("kerosine(euro/MWh)")]
    public decimal Kerosine { get; set; }

    [JsonPropertyName("co2(euro/ton)")] public int CarbonDioxide { get; set; }
    [JsonPropertyName("wind(%)")] public int Wind { get; set; }
}

public class PowerplantDto
{
    public string Name { get; set; }
    public string Type { get; set; }
    public decimal Efficiency { get; set; }
    public int PMin { get; set; }
    public int PMax { get; set; }
}