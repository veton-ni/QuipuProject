using Application.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence
{
    public interface IUnitOfWork
    {
        DbContext _context { get; }
        IClientRepository client { get; }
        IAddressRepository address { get; }

        Task<int> Complete();
    }
}
