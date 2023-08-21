namespace Facul.Domain;

public interface IFareCalculator
{
    public decimal Calculate(Segment segment);
}
