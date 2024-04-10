using Application.Persistence.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(DbContext Context) : base(Context)
        {
        }
    }
}
