using Domain.Entity;
using Domain.Enums;
using QuipuWeb.Dto;

namespace QuipuWeb.Extension
{
    public static class AddressDTOExtension
    {
        public static Address FromDTO(this AddressCreateUpdateRequestDTO clientDTO)
        {
            Address client = new()
            {
                Name = clientDTO.name,
                PostCode = clientDTO.postCode,
                IdClient = clientDTO.IdClient,
                Type = clientDTO.type.ToEnum<AddressTypeEnum>()
            };

            return client;
        }

        public static AddressCreateUpdateResponsDTO ToResponseDTO(this Address client)
        {
            AddressCreateUpdateResponsDTO clientDTO = new(client.Id, client.Name, client.PostCode, client.IdClient, client.Type);

            return clientDTO;
        }
        public static AddressDTO ToDTO(this Address client)
        {
            AddressDTO clientDTO = new(client.Id, client.Name, client.PostCode, client.IdClient, client.Type);

            return clientDTO;
        }

    }

}
