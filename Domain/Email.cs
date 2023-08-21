using System.Text.RegularExpressions;

namespace Facul.Domain;

public class Email
{
    public string Value { get; set; }

    public Email(string value)
    {
        if (!Validate(value)) throw new Exception("Invalid email");
        Value = value;
    }

    private bool Validate(string email)
    {
        Regex regex = new Regex("/^(([^<>()[\\]\\\\.,;:\\s@\"]+(\\.[^<>()[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$/");
        return regex.IsMatch(email.ToLower());
    }
}
