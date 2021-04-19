using Cerberus.Domain.Enums;

namespace Cerberus.Domain.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public PetType Type { get; set; }
        public string Name { get; set; }
    }
}