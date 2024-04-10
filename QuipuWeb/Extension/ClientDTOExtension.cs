using Domain.Entity;
using QuipuWeb.Dto;

namespace QuipuWeb.Extension
{

    public static class ClientDTOExtension
    {
        public static Client FromDTO(this ClientCreateUpdateRequestDTO clientDTO)
        {
            Client client = new()
            {
                Name = clientDTO.name,
                Email = clientDTO.email,
                Phone = clientDTO.phone,
                Birthdate = clientDTO.birthdate
            };

            return client;
        }

        public static ClientCreateUpdateResponsDTO ToResponseDTO(this Client client)
        {
            ClientCreateUpdateResponsDTO clientDTO = new(client.Id, client.Name, client.Email, client.Phone, client.Birthdate);

            return clientDTO;
        }
        public static ClientDTO ToDTO(this Client client)
        {
            List<AddressDTO> addresses = new();

            if (client.ListAddresses != null)
                foreach (var address in client.ListAddresses)
                    addresses.Add(address.ToDTO());

            ClientDTO clientDTO = new(client.Id, client.Name, client.Email, client.Phone, client.Birthdate, addresses);

            return clientDTO;
        }

    }
}
