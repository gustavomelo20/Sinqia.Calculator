using Sinqia.Calculator.Domain.Dtos.Request;
using Sinqia.Calculator.Domain.Dtos.Responses;
using Sinqia.Calculator.Domain.Repositories.Cotacao;

namespace Sinqia.Calculator.Application.useCase.Investment;

public class CalculateInvestmentUseCase : ICalculateInvestmentUseCase
{
    private readonly ICotacaoReadOnlyRepository _cotacaoRepository;

    public CalculateInvestmentUseCase(ICotacaoReadOnlyRepository cotacaoRepository)
    {
        _cotacaoRepository = cotacaoRepository;
    }

    public async Task<CalculateInvestmentResponse> ExecuteAsync(CalculateInvestmentRequest request)
    {
        var quotations = await _cotacaoRepository.GetByPeriodAsync(request.StartDate, request.EndDate);

        var businessDays = FilterBusinessDays(quotations, request.StartDate, request.EndDate);

        var accumulatedFactor = CalculateAccumulatedFactor(businessDays);

        var updatedValue = CalculateUpdatedValue(request.InvestedAmount, accumulatedFactor);

        return new CalculateInvestmentResponse
        {
            InvestedAmount = request.InvestedAmount,
            UpdatedAmount = updatedValue,
            AccumulatedFactor = accumulatedFactor,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };
    }

    private List<Domain.Entities.Cotacao> FilterBusinessDays(IEnumerable<Domain.Entities.Cotacao> quotations, DateTime start, DateTime end)
    {
        return quotations
            .Where(q => q.Data > start && q.Data < end)
            .OrderBy(q => q.Data)
            .ToList();
    }

    private decimal CalculateAccumulatedFactor(IEnumerable<Domain.Entities.Cotacao> quotations)
    {
        decimal factor = 1m;

        foreach (var quotation in quotations)
        {
            var dailyFactor = CalculateDailyFactor(quotation.Valor);
            factor *= dailyFactor;
            factor = TruncateDecimal(factor, 16);
        }

        return factor;
    }

    private decimal CalculateDailyFactor(decimal annualRatePercent)
    {
        var annualRate = annualRatePercent / 100m;
        var daily = Math.Pow((double)(1 + annualRate), 1.0 / 252.0);
        return Math.Round((decimal)daily, 8, MidpointRounding.ToZero);
    }

    private decimal CalculateUpdatedValue(decimal investedAmount, decimal accumulatedFactor)
    {
        return TruncateDecimal(investedAmount * accumulatedFactor, 8);
    }

    private decimal TruncateDecimal(decimal value, int decimals)
    {
        decimal factor = (decimal)Math.Pow(10, decimals);
        return Math.Truncate(value * factor) / factor;
    }
}