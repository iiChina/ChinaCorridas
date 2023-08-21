namespace Facul.Domain
{
    public class Ride
    {
        public List<Position> Positions { get; set; }
        const decimal MIN_PRICE = 10;

        public Ride()
        {
            Positions = new List<Position>();
        }

        public void AddPosition(float lat, float lon, DateTime date)
        {
            Positions.Add(new Position(lat, lon, date));
        }

        public decimal Calculate()
        {
            var price = 0M;
            for (int i = 0; i < Positions.Count; i++)
            {
                var nextPosition = Positions[i + 1];
                if (nextPosition == null) break;
                var distance = DistanceCalculator.Calculate(Positions[i].Coord, nextPosition.Coord);
                var segment = new Segment(distance, nextPosition.Date);
                var fareCalculator = FareCalculatorFactory.Create(segment);
                price += fareCalculator.Calculate(segment);
            }
            return (price < MIN_PRICE) ? MIN_PRICE : price;
        }
    }
}
