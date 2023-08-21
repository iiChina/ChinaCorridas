namespace Facul.Domain;

public static class FareCalculatorFactory
{
    public static IFareCalculator Create(Segment segment)
    {
        if(segment.IsOvernight() && !segment.IsSunday())
        {
            return new OvernightFareCalculator();
        }
        if(segment.IsOvernight() && segment.IsSunday())
        {
            return new OvernightSundayFareCalculator();
        }
        if (!segment.IsOvernight() && segment.IsSunday())
        {
            return new SundayFareCalculator();
        }
        if (!segment.IsOvernight() && !segment.IsSunday())
        {
            return new NormalFareCalculator();
        }
        throw new Exception("Invalid segment");
    }
}
