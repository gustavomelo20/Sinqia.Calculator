using Microsoft.Extensions.DependencyInjection;
using Sinqia.Calculator.Application.useCase.Cotacao;
using Sinqia.Calculator.Application.useCase.Investment;

namespace Sinqia.Calculator.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCase(services);
    }
    
    private static void AddUseCase(IServiceCollection services)
    {
        services.AddScoped<IGetCotacaoUseCase, GetCotacaoUseCase>();
        services.AddScoped<ICalculateInvestmentUseCase, CalculateInvestmentUseCase>();
    }
}