using Application.Persistence;
using Application.Persistence.Repository;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext _context { get; private set; }

        public IClientRepository client { get; private set; }
        public IAddressRepository address { get; private set; }


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            client = new ClientRepository(_context);
            address = new AddressRepository(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }



    }
}
