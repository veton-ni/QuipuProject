using Application.Common.DateTimeContract;
using Application.Exceptions;
using Application.Persistence;
using Application.Service;
using Domain.Entity;

namespace Infrastructure.Service
{
    public class ClientService : ServiceBase<Client>, IClientService
    {
        public IAddressService addressService { get; set; }

        public ClientService(IUnitOfWork unitOfWork, IDateTimeProvider dateTime, IAddressService addressService)
            : base(unitOfWork, unitOfWork.client, dateTime)
        {
            this.addressService = addressService;
        }

        public async Task<Address> AddAddress(Guid idClient, Address address)
        {
            var _ = await _unitOfWork.client.Get(idClient) ?? throw new BadRequestException($"Client with id {idClient} was not found!");

            address.IdClient = idClient;
            await addressService.Add(address);

            return address;

        }
    }
}
