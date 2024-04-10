using Application.Service;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using QuipuWeb.Extension;
using QuipuWeb.XmlDTO;
using System.Text;

namespace QuipuWeb.Controllers
{
    public class ImportController : Controller
    {

        private readonly IClientService _clientService;

        public ImportController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult ImportXML()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> ImportXmlData(IFormFile xmlFile)
        {

            ClientsXmlRoot clients = await XMLUtil.GetClientData(xmlFile);

            List<Client> clientList = new();

            foreach(var xmlClient in clients.Clients)
            {
                clientList.Add(xmlClient.ToClient());
            }

            await _clientService.Add(clientList);


            return Redirect("~/Home/Index");
        }


    }
}
