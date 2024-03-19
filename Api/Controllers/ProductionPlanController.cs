using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ngneerd.PowerplantCodingChallenge.Application.Handlers.Commands;
using Ngneerd.PowerplantCodingChallenge.Application.Models.DataTransferObjects;

namespace Ngneerd.PowerplantCodingChallenge.Api.Controllers;

[Route("api/production-plan")]
[ApiController]
[ApiVersion("0.1")]
public class ProductionPlanController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductionPlanController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateProductionPlan([FromBody] ProductionPlanInputDto inputDto)
    {
        var result = await _mediator.Send(new GenerateProductionPlanCommand(inputDto));
        return Ok(result);
    }
}