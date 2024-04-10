using Application.Persistence.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DbContext Context) : base(Context)
        {
        }
    }
}
