namespace Facul.Domain;

public class DistanceCalculator
{
    public static double Calculate(Coord from, Coord to)
    {
        var earthRadius = 6371;
        var degreesToRadians = Math.PI / 180;
        var deltaLat = (to.Lat - from.Lat) * degreesToRadians;
        var deltaLon = (to.Lon - from.Lon) * degreesToRadians;
        var a = 
            Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) + 
            Math.Cos(from.Lat * degreesToRadians) * 
            Math.Cos(to.Lat * degreesToRadians) * 
            Math.Sin(deltaLon / 2) * 
            Math.Sin(deltaLon / 2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        var distance = earthRadius * c;
        return Math.Round(distance);
    }
}
