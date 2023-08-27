namespace Facul.Domain;

public class Position
{
    public Coord Coord { get; set; }
    public DateTime Date { get; set; }

    public Position(float lat, float lon, DateTime date)
    {
        Coord = new Coord(lat, lon);
        Date = date;
    }
}
