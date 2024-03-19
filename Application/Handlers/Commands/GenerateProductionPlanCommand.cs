using MediatR;
using Microsoft.Extensions.Logging;
using Ngneerd.PowerplantCodingChallenge.Application.Models.DataTransferObjects;
using Ngneerd.PowerplantCodingChallenge.Domain.Entities;
using Ngneerd.PowerplantCodingChallenge.Domain.Entities.Fuels;
using Ngneerd.PowerplantCodingChallenge.Domain.Entities.Powerplants;
using Ngneerd.PowerplantCodingChallenge.Domain.Exceptions;

namespace Ngneerd.PowerplantCodingChallenge.Application.Handlers.Commands;

public record GenerateProductionPlanCommand(ProductionPlanInputDto Input) : IRequest<ProductionPlanOutputDto>;

public class
    GenerateProductionPlanCommandHandler : IRequestHandler<GenerateProductionPlanCommand, ProductionPlanOutputDto>
{
    #region Fields

    private readonly ILogger<GenerateProductionPlanCommandHandler> _logger;

    #endregion

    #region Constructors

    public GenerateProductionPlanCommandHandler(ILogger<GenerateProductionPlanCommandHandler> logger)
    {
        _logger = logger;
    }

    #endregion

    #region Public Methods

    public Task<ProductionPlanOutputDto> Handle(GenerateProductionPlanCommand request,
        CancellationToken cancellationToken)
    {
        var powerplants = new List<IPowerplant>();
        foreach (var powerplant in request.Input.Powerplants)
        {
            // TODO: Switch to custom mapping ? 
            powerplants.Add(GetPowerplantFromDto(powerplant, request.Input.FuelsPrices));
        }

        var productionPlan = new ProductionPlan(request.Input.Load, powerplants);
        var planGenerated = productionPlan.Generate();
        if (!planGenerated)
            throw new ProductionPlanGenerationFailedException();

        var powerplantsWithPower = new List<PowerByPowerplantDto>();
        foreach (var powerplant in productionPlan.RequiredPowerPerPowerplant)
        {
            if (powerplant.Value != null)
                powerplantsWithPower.Add(new PowerByPowerplantDto(powerplant.Key.Name, powerplant.Value.Value));
        }

        return Task.FromResult(new ProductionPlanOutputDto(powerplantsWithPower));
    }

    #endregion

    #region Private Methods

    private IPowerplant GetPowerplantFromDto(PowerplantDto powerplantDto, FuelPricesDto fuelsPrices)
    {
        return powerplantDto.Type switch
        {
            "gasfired" => new GasFired(new Gas(fuelsPrices.Gas, fuelsPrices.CarbonDioxide),
                powerplantDto.Name,
                powerplantDto.Efficiency,
                powerplantDto.PMax,
                powerplantDto.PMin),
            "turbojet" => new Turbojet(new Kerosine(fuelsPrices.Kerosine),
                powerplantDto.Name,
                powerplantDto.Efficiency,
                powerplantDto.PMax,
                powerplantDto.PMin),
            "windturbine" => new WindTurbine(new Wind(fuelsPrices.Wind),
                powerplantDto.Name,
                powerplantDto.Efficiency,
                powerplantDto.PMax,
                powerplantDto.PMin),
            _ => throw new PowerplantTypeNotFoundException()
        };
    }

    #endregion
}