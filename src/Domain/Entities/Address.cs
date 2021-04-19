namespace Cerberus.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}