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
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return regex.IsMatch(email.ToLower().Trim());
    }
}
