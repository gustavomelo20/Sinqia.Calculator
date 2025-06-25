namespace Sinqia.Calculator.Domain.Dtos.Responses;

public class CalculateInvestmentResponse
{
    public decimal InvestedAmount { get; set; }
    public decimal UpdatedAmount { get; set; }
    public decimal AccumulatedFactor { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}