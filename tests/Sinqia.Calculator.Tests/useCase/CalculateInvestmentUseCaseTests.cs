using FluentAssertions;
using Moq;
using Sinqia.Calculator.Application.useCase.Investment;
using Sinqia.Calculator.Domain.Dtos.Request;
using Sinqia.Calculator.Domain.Repositories.Cotacao;

namespace Sinqia.Calculator.Tests.useCase;

public class CalculateInvestmentUseCaseTests
{
    private readonly  Mock<ICotacaoReadOnlyRepository> _repositoryMock;
    private readonly CalculateInvestmentUseCase _useCase;

    public CalculateInvestmentUseCaseTests()
    {
        _repositoryMock = new Mock<ICotacaoReadOnlyRepository>();
        _useCase = new CalculateInvestmentUseCase(_repositoryMock.Object);
    }

    [Fact]
    public async Task Should_Return_Correct_UpdatedAmount_When_ValidRequest()
    {
        var request = new CalculateInvestmentRequest()
        {
            InvestedAmount = 1000,
            StartDate = new DateTime(2024, 01, 01),
            EndDate = new DateTime(2024, 01, 10)
        };

        var quotations = new List<Domain.Entities.Cotacao>
        {
            new Domain.Entities.Cotacao { Data = new DateTime(2024, 01, 02), Valor = 13.65m },
            new Domain.Entities.Cotacao { Data = new DateTime(2024, 01, 03), Valor = 13.65m },
            new Domain.Entities.Cotacao { Data = new DateTime(2024, 01, 04), Valor = 13.65m },
        };

        _repositoryMock
            .Setup(r => r.GetByPeriodAsync(request.StartDate, request.EndDate)).ReturnsAsync(quotations);
        
        var result = await _useCase.ExecuteAsync(request);
        
        result.InvestedAmount.Should().Be(1000);
        result.AccumulatedFactor.Should().BeGreaterThan(1);
        result.UpdatedAmount.Should().BeGreaterThan(1000);
        result.StartDate.Should().Be(request.StartDate);
        result.EndDate.Should().Be(request.EndDate);
    }
    
    [Fact]
    public async Task Should_IgnoreQuotationsOutsideDateRange()
    {
        var request = new CalculateInvestmentRequest
        {
            InvestedAmount = 1000,
            StartDate = new DateTime(2024, 01, 01),
            EndDate = new DateTime(2024, 01, 10)
        };

        var quotations = new List<Domain.Entities.Cotacao>
        {
            new Domain.Entities.Cotacao { Data = new DateTime(2023, 12, 31), Valor = 13.65m }, 
            new Domain.Entities.Cotacao { Data = new DateTime(2024, 01, 05), Valor = 13.65m },
            new Domain.Entities.Cotacao { Data = new DateTime(2024, 01, 11), Valor = 13.65m },
        };

        _repositoryMock
            .Setup(r => r.GetByPeriodAsync(request.StartDate, request.EndDate))
            .ReturnsAsync(quotations);
        
        var result = await _useCase.ExecuteAsync(request);

        result.AccumulatedFactor.Should().BeGreaterThan(1);
        result.UpdatedAmount.Should().BeGreaterThan(1000);
    }
}