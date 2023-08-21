namespace Facul.Domain;

public static class UUIDGenerator
{
    public static string Create()
    {
        return Guid.NewGuid().ToString();
    }
}
