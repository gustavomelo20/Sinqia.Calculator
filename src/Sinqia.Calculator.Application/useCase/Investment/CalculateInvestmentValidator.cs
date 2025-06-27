using FluentValidation;
using Sinqia.Calculator.Domain.Dtos.Request;

namespace Sinqia.Calculator.Application.useCase.Investment;

public class CalculateInvestmentValidator: AbstractValidator<CalculateInvestmentRequest>
{
    public CalculateInvestmentValidator()
    {
        RuleFor(x => x.InvestedAmount)
            .GreaterThan(0)
            .WithMessage("The amount invested must be greater than zero.");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("The end date must be greater than the application date.");
    }
}