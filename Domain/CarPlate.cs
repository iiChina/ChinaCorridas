using System.Text.RegularExpressions;

namespace Facul.Domain
{
    public class CarPlate
    {
        public string Value { get; set; }

        public CarPlate(string value)
        {
            if (!Validate(value)) throw new Exception("Invalid car plate");
            Value = value;
        }

        private bool Validate(string carPlate)
        {
            var regex = new Regex("/^[a-z]{3}[0-9]{4}$/");
            return regex.IsMatch(carPlate.ToLower());
        }
    }
}
