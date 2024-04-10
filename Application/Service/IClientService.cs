using Domain.Entity;


namespace Application.Service
{
    public interface IClientService : IBaseService<Client>
    {
        Task<Address> AddAddress(Guid idClient, Address address);

    }
}
