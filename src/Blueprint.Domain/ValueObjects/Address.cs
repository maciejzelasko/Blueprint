namespace Blueprint.Domain.ValueObjects
{
    public record Address
    {
        private Address(string street, string zipCode)
        {
            Street = street;
            ZipCode = zipCode;
        }

        public string Street { get; }
        public string ZipCode { get; }

        public static Address Create(string street, string zipCode) => new (street, zipCode);
    }
}