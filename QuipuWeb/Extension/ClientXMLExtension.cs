using Domain.Entity;
using Domain.Enums;
using QuipuWeb.XmlDTO;
using System.Globalization;

namespace QuipuWeb.Extension
{
    public static class ClientXMLExtension
    {

        public static Client ToClient(this ClientXML clientXML)
        {
            Client client = new() { 
                Name = clientXML.Name,
                Email = clientXML.Email,
                Phone = clientXML.Phone,
                Birthdate = DateTime.ParseExact(clientXML.Birthdate, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                ListAddresses = new List<Address>()
            };
            
            foreach(var address in clientXML.Address)
            {
                client.ListAddresses.Add(address.ToAddress());
            }

            return client;
        }

        public static Address ToAddress(this AddressXML addressXML)
        {
            Address address = new()
            {
                Name = addressXML.Name,
                PostCode = addressXML.PostCode.ToString(),
                Type = addressXML.Type.ToEnum<AddressTypeEnum>()
            };

            return address;
        }


    }
}
