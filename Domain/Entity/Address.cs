using Domain.Enums;

namespace Domain.Entity
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }
        public string? PostCode { get; set; }
        public AddressTypeEnum Type { get; set; }


        public Guid? IdClient { get; set; }
        public Client? client { get; set; }
    }
}
