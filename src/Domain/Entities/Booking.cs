using Cerberus.Domain.Enums;
using System.Collections.Generic;

namespace Cerberus.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public BookingType Type { get; set; }
        public Customer Customer { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}