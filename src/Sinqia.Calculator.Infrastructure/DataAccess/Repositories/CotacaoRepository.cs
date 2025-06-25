using Sinqia.Calculator.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Sinqia.Calculator.Domain.Entities;

namespace Sinqia.Calculator.Infrastructure.DataAccess.Repositories;

public class CotacaoRepository : ICotacaoReadOnlyRepository
{
    private readonly SinqiaCalculatorDbContext _dbContext;

    public CotacaoRepository(SinqiaCalculatorDbContext dbContext) => _dbContext = dbContext;

    public async Task<IList<Cotacao>> Filter()
    {
        return await _dbContext.Cotacoes.AsNoTracking().ToListAsync();
    }
}