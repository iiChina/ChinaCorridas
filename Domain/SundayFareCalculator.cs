namespace Facul.Domain;

public class SundayFareCalculator : IFareCalculator
{
    const decimal FARE = 2.9M;

    public decimal Calculate(Segment segment) => (decimal)segment.Distance * FARE;
}
