using Application.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuipuWeb.Dto;
using QuipuWeb.Extension;
using System.Text;

namespace QuipuWeb.Controllers
{


    public class ExportController : Controller
    {
        private readonly IClientService _clientService;

        public ExportController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult JsonExporter()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> ExportData(ExportDataRequest data)
        {
            string orderByName = data.orderByName != "on" ? "" : (data.orderByNameType != "on" ? "Name" : "NameDesc");
            string orderByBirthdate = data.orderByBirthdate != "on" ? "" : (data.orderByBirthdateType != "on" ? "Birthdate" : "BirthdateDesc");

            var orderBy = string.Join(",", orderByName, orderByBirthdate).Trim(',');

            var clients = await _clientService.Find(null, orderBy: orderBy, include: "ListAddresses");

            List<ClientDTO> clientsDTO = new();
            foreach (var client in clients)
            {
                clientsDTO.Add(client.ToDTO());
            }

            string jsonClient = JsonConvert.SerializeObject(clientsDTO);

            return File(Encoding.ASCII.GetBytes(jsonClient), "application/json", "ExportClientData.json");
        }
    }
}
