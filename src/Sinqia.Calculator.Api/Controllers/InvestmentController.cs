using Microsoft.AspNetCore.Mvc;
using Sinqia.Calculator.Application.useCase.Investment;
using Sinqia.Calculator.Domain.Dtos.Request;
using Sinqia.Calculator.Domain.Dtos.Responses;

namespace Sinqia.Calculator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvestmentController : ControllerBase
{
    [HttpPost("calculate")]
    [ProducesResponseType(typeof(CalculateInvestmentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CalculateInvestment(
        [FromServices] ICalculateInvestmentUseCase useCase,
        [FromBody] CalculateInvestmentRequest request
    )
    {
            var result = await useCase.ExecuteAsync(request);
            return Ok(result);
    }
}