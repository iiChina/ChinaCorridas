namespace Facul.Domain;

public class OvernightFareCalculator : IFareCalculator
{
    const decimal FARE = 3.9M;

    public decimal Calculate(Segment segment) => (decimal)segment.Distance * FARE;
}
