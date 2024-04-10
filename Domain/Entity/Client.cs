

namespace Domain.Entity
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }

        public DateTime? Birthdate { get; set; }


        public virtual ICollection<Address>? ListAddresses { get; set; }
    }
}
