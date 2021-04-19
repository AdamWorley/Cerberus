using System.Collections.Generic;

namespace Cerberus.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
        public Address Address { get; set; }
        public List<ContactDetails> ContactDetails { get; set; } = new List<ContactDetails>();
    }
}