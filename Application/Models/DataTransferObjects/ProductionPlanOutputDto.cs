namespace Ngneerd.PowerplantCodingChallenge.Application.Models.DataTransferObjects;

public record ProductionPlanOutputDto(List<PowerByPowerplantDto> Powerplants);

public record PowerByPowerplantDto(string Name, decimal power);