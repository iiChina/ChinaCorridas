using System.Diagnostics;

namespace Facul.Domain
{
    public class Segment
    {
        public float Distance { get; }
        public DateTime Date { get; set; }

        public Segment(float distance, DateTime date)
        {
            if (!IsValidDistance()) throw new Exception("Invalid distance");
            if (!IsValidDistance()) throw new Exception("Invalid date");

            Distance = distance;
            Date = date;
        }

        public bool IsOvernight() => Date.Hour >= 22 || Date.Hour <= 6;

        public bool IsSunday() => Date.Day == 0;

        public bool IsValidDistance() => Distance > 0;

        public bool IsValidDate() => Date != null;
    }
}
