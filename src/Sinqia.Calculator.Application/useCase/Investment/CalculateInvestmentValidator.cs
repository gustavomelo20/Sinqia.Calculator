using FluentValidation;
using Sinqia.Calculator.Domain.Dtos.Request;

namespace Sinqia.Calculator.Application.useCase.Investment;

public class CalculateInvestmentValidator: AbstractValidator<CalculateInvestmentRequest>
{
    public CalculateInvestmentValidator()
    {
        RuleFor(x => x.InvestedAmount)
            .GreaterThan(0)
            .WithMessage("O valor investido deve ser maior que zero.");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("A data final deve ser maior que a data de aplicação.");
    }
}