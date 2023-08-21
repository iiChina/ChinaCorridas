namespace Facul.Domain;

public class Driver
{
    public string Id { get; }
    public string Name { get; }
    public Cpf Document { get; set; }
    public Email Email { get; set; }
    public CarPlate CarPlate { get; set; }

    private Driver(string id, string name, string email, string document, string carPlate)
    {
        Name = name;
        Document = new Cpf(document);
        Email = new Email(email);
        CarPlate = new CarPlate(carPlate);
    }

    public static Driver Create(string name, string email, string document, string carPlate)
    {
        var driverId = UUIDGenerator.Create();
        return new Driver(driverId, name, email, document, carPlate);
    }
}
