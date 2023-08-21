namespace Facul.Domain;

public class OvernightSundayFareCalculator : IFareCalculator
{
    const decimal FARE = 5;

    public decimal Calculate(Segment segment) => (decimal)segment.Distance * FARE;
    
}
