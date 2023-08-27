using System.Diagnostics;

namespace Facul.Domain
{
    public class Segment
    {
        public double Distance { get; }
        public DateTime Date { get; set; }

        public Segment(double distance, DateTime date)
        {
            if (!IsValidDistance(distance)) throw new Exception("Invalid distance");
            if (!IsValidDate(date)) throw new Exception("Invalid date");

            Distance = distance;
            Date = date;
        }

        public bool IsOvernight() => Date.Hour >= 22 || Date.Hour <= 6;

        public bool IsSunday() => Date.Day == 0;

        public bool IsValidDistance(double distance) => distance > 0;

        public bool IsValidDate(DateTime date) => date != null;
    }
}
