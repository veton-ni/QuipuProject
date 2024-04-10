using Application.Common.DateTimeContract;
using Application.Persistence;
using Application.Service;
using Domain.Entity;

namespace Infrastructure.Service
{
    public class AddressService : ServiceBase<Address>, IAddressService
    {
        public AddressService(IUnitOfWork unitOfWork, IDateTimeProvider dateTime) 
            : base(unitOfWork, unitOfWork.address, dateTime)
        {
        }
    }
}
