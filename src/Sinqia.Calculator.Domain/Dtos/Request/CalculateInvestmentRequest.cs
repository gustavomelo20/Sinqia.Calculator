namespace Sinqia.Calculator.Domain.Dtos.Request;

public class CalculateInvestmentRequest
{
    public decimal InvestedAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}