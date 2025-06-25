using Sinqia.Calculator.Domain.Entities;

namespace Sinqia.Calculator.Domain.Repositories;

public interface  ICotacaoReadOnlyRepository
{
    public Task<IList<Cotacao>> Filter();
}