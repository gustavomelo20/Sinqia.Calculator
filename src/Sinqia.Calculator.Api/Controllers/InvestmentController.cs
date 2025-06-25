using Microsoft.AspNetCore.Mvc;
using Sinqia.Calculator.Application.useCase.Investment;
using Sinqia.Calculator.Domain.Dtos.Request;
using Sinqia.Calculator.Domain.Dtos.Responses;

namespace Sinqia.Calculator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvestmentController : ControllerBase
{
    private readonly ICalculateInvestmentUseCase _calculateInvestmentUseCase;

    public InvestmentController(ICalculateInvestmentUseCase calculateInvestmentUseCase)
    {
        _calculateInvestmentUseCase = calculateInvestmentUseCase;
    }

    [HttpPost("calculate")]
    [ProducesResponseType(typeof(CalculateInvestmentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CalculateInvestment([FromBody] CalculateInvestmentRequest request)
    {
        try
        {
            var result = await _calculateInvestmentUseCase.ExecuteAsync(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno ao calcular aplicação.", detail = ex.Message });
        }
    }
}