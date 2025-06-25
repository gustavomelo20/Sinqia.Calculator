using Microsoft.AspNetCore.Mvc;
using Sinqia.Calculator.Application.useCase.Cotacao;
using Sinqia.Calculator.Domain.Entities;

namespace Sinqia.Calculator.Api.Controllers;

[Route("cotacao")]
[ApiController]
public class CotacaoController : ControllerBase
{
    [HttpGet]
    public async Task<IList<Cotacao>> Get([FromServices] IGetCotacaoUseCase useCase)
    {
        return await useCase.Execute();
    }
}