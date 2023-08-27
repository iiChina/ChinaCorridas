namespace Facul.Domain;

public class Cpf
{
    public string Value { get; set; }

    public Cpf(string value)
    {
        if (!Validate(value)) throw new Exception("Invalid cpf");
        Value = value;
    }

    private bool Validate(string cpf)
    {
        cpf = Clean(cpf);
        if (!IsValidLength(cpf)) return false;
        if (HasAllDigitsEqual(cpf)) return false;
        var dg1 = CalculateDigit(cpf, 10);
        var dg2 = CalculateDigit(cpf, 11);
        return ExtractCheckDigit(cpf) == $"{dg1}{dg2}";
    }

    private string Clean(string cpf)
    {
        return cpf.Replace("/\\D/g", "").Trim();
    }

    private bool IsValidLength(string cpf)
    {
        return cpf.Length == 11;
    }

    private bool HasAllDigitsEqual(string cpf)
    {
        var firstDigit = cpf.Substring(0, 1);
        foreach(var digit in cpf)
        {
            if (digit.ToString() != firstDigit) return false;
        }
        return true;
    }

    private int CalculateDigit(string cpf, int factor)
    {
        var total = 0;
        foreach (var digit in cpf)
        {
            if (factor > 1) total += Int32.Parse(digit.ToString()) * factor--;
        }

        var rest = total % 11;
        return (rest < 2) ? 0 : 11 - rest;
    }

    private string ExtractCheckDigit(string cpf)
    {
        return cpf.Substring(9);
    }
}
