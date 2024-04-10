using System.Text;
using System.Xml.Schema;
using System.Xml;
using Application.Exceptions;
using System.Xml.Serialization;
using System.IdentityModel.Tokens.Jwt;

namespace QuipuWeb.XmlDTO
{
    public static class XMLUtil
    {

        private static readonly string XSD_PATH = "XmlDTO\\xsd\\ClientXSD.xsd";

        public static async Task<ClientsXmlRoot> GetClientData(IFormFile file) {

            string xmlPath = await UploadXMLFile(file);

            ValidateXML(xmlPath);

            ClientsXmlRoot clients = ReadFromXML(xmlPath);

            return clients;
        }

        private static async Task<string> UploadXMLFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                return filePath;
            }

            return "";
        }
        private static void ValidateXML(string xmlPath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlPath);

            string fullPath = Path.GetFullPath("~").Trim('~');
            string fullPath1 = Path.GetFullPath("~/");
            string ss = Path.Combine(fullPath, XSD_PATH);

            xml.Schemas.Add(null, ss);

            try
            {
                xml.Validate(null);
            }
            catch (XmlSchemaValidationException ex)
            {
                throw new BadRequestException("XML file is not valide against XSD file", ex);
            }
        }

        private static ClientsXmlRoot ReadFromXML(string xmlPath)
        {
            //XmlSerializer s = new XmlSerializer(typeof(Clients));
            //using (StringReader reader = new StringReader(xmlPath))
            //{
            //    object obj = s.Deserialize(reader);
            //    return (Clients)obj;
            //}
            XmlSerializer serializer = new XmlSerializer(typeof(ClientsXmlRoot));
            using (Stream reader = new FileStream(xmlPath, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                return (ClientsXmlRoot)serializer.Deserialize(reader);
            }

        }




    }
}
