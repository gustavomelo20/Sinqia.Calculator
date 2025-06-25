

using Sinqia.Calculator.Domain.Repositories.Cotacao;

namespace Sinqia.Calculator.Application.useCase.Cotacao;

public class GetCotacaoUseCase : IGetCotacaoUseCase
{
    private readonly ICotacaoReadOnlyRepository _repositoryRead;
    
    public GetCotacaoUseCase(
        ICotacaoReadOnlyRepository repositoryRead
    )
    {
        _repositoryRead = repositoryRead; 
    }
    
    public async Task<IList<Domain.Entities.Cotacao>> Execute(DateTime dataInicio, DateTime dataFim)
    {
       return await _repositoryRead.GetByPeriodAsync(dataInicio, dataFim);
    }
}