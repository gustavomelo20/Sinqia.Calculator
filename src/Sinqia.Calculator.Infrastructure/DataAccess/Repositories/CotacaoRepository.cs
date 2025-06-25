using Microsoft.EntityFrameworkCore;
using Sinqia.Calculator.Domain.Entities;
using Sinqia.Calculator.Domain.Repositories.Cotacao;

namespace Sinqia.Calculator.Infrastructure.DataAccess.Repositories;

public class CotacaoRepository : ICotacaoReadOnlyRepository
{
    private readonly SinqiaCalculatorDbContext _dbContext;

    public CotacaoRepository(SinqiaCalculatorDbContext dbContext) => _dbContext = dbContext;

    public async Task<IList<Cotacao>> GetByPeriodAsync(DateTime dataInicio, DateTime dataFim)
    {
        return await _dbContext.Cotacoes
            .AsNoTracking()
            .Where(c => c.Data >= dataInicio && c.Data < dataFim)
            .OrderBy(c => c.Data)
            .ToListAsync();
    }
}