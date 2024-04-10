using System.Xml.Serialization;

namespace QuipuWeb.XmlDTO
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Clients));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Clients)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "address")]
    public class AddressXML
    {

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "postCode")]
        public int PostCode { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public int Type { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Client")]
    public class ClientXML
    {

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "phone")]
        public string Phone { get; set; }

        [XmlElement(ElementName = "birthdate")]
        public string Birthdate { get; set; }

        [XmlElement(ElementName = "address")]
        public List<AddressXML> Address { get; set; }

    }

    [XmlRoot(ElementName = "Clients")]
    public class ClientsXmlRoot
    {

        [XmlElement(ElementName = "Client")]
        public List<ClientXML> Clients { get; set; }

    }


}