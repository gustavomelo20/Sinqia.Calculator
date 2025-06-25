namespace Sinqia.Calculator.Domain.Repositories.Cotacao;

public interface  ICotacaoReadOnlyRepository
{
    public Task<IList<Domain.Entities.Cotacao>> GetByPeriodAsync(DateTime dataInicio, DateTime dataFim);
}