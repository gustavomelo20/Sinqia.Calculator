namespace Sinqia.Calculator.Application.useCase.Cotacao;

public interface IGetCotacaoUseCase
{
    public Task<IList<Domain.Entities.Cotacao>> Execute(DateTime dataInicio, DateTime dataFim);
}