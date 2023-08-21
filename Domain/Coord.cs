namespace Facul.Domain;

public class Coord
{
    public float Lat { get; }
    public float Lon { get; }
    public Coord(float lat, float lon) 
    {
        Lat = lat;
        Lon = lon;
    }
}
