using Sinqia.Calculator.Domain.Dtos.Request;
using Sinqia.Calculator.Domain.Dtos.Responses;

namespace Sinqia.Calculator.Application.useCase.Investment;

public interface ICalculateInvestmentUseCase
{
    public Task<CalculateInvestmentResponse> ExecuteAsync(CalculateInvestmentRequest request);
}