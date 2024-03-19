namespace Ngneerd.PowerplantCodingChallenge.Domain.Entities;

public interface IPowerplant
{
    string Name { get; set; }
    decimal PMax { get; set; }
    decimal PMin { get; set; }
    decimal CostPerMWh();
}