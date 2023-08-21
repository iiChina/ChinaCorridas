namespace Facul.Domain
{
    public class NormalFareCalculator : IFareCalculator
    {
        const decimal FARE = 2.1M;
        public decimal Calculate(Segment segment) 
            => (decimal)segment.Distance * FARE;
    }
}
