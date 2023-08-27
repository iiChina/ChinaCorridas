namespace Facul.Domain
{
    public class Passenger
    {
        public string Id { get; }
        public string Name { get; }
        public Cpf Document { get; set; }
        public Email Email { get; set; }

        public Passenger(string id, string name, string document, string email)
        {
            Id = id;
            Name = name;
            Document = new Cpf(document);
            Email = new Email(email);
        }

        public static Passenger Create(string name, string email, string document)
        {
            var passengerId = UUIDGenerator.Create();
            return new Passenger(passengerId, name, document, email);
        }

    }
}
