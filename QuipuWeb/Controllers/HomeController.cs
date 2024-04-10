using Application.Service;
using Microsoft.AspNetCore.Mvc;
using QuipuWeb.Dto;
using QuipuWeb.Extension;

namespace QuipuWeb.Controllers
{

    public class HomeController : Controller
    {

        private readonly IClientService _clientService;
        private readonly IAddressService _addressService;


        public HomeController(IClientService clientService, IAddressService addressService)
        {
            _clientService = clientService;
            _addressService = addressService;
        }

        public async Task<IActionResult> Index()
        {
            List<ClientDTO> listClientDTO = new();

            var clients = await _clientService.Find(null, orderBy: "Name", include: "ListAddresses");

            foreach (var client in clients)
            {
                listClientDTO.Add(client.ToDTO());
            }

            return View(listClientDTO);
        }

        public async Task<IActionResult> ClientEdit(Guid id)
        {
            var clients = await _clientService.FindFirst(x => x.Id == id, include: "ListAddresses");

            return View("ClientPage", clients.ToDTO());
        }
        
        public IActionResult ClientNew()
        {
            return View("ClientPage", null);
        }

        public async Task<IActionResult> AddressEdit(Guid id)
        {
            var address = await _addressService.FindFirst(x => x.Id == id);

            ViewData["IdClient"] = address.IdClient;
            return View("AddressPage", address.ToDTO());
        }

        public IActionResult AddressNew(Guid id)
        {
            ViewData["IdClient"] = id;
            return View("AddressPage", null);
        }



    }
}
