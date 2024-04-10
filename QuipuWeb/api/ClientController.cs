using Application.Service;
using Domain.Entity;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuipuWeb.Dto;
using QuipuWeb.Extension;
using System;
using System.Text;

namespace QuipuWeb.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IValidator<ClientCreateUpdateRequestDTO> _clientValidator;
        private readonly IValidator<AddressCreateUpdateRequestDTO> _addressValidator;

        public ClientController(IClientService clientService, IValidator<ClientCreateUpdateRequestDTO> clientValidator, IValidator<AddressCreateUpdateRequestDTO> addressValidator)
        {
            _clientService = clientService;
            _clientValidator = clientValidator;
            _addressValidator = addressValidator;
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _clientService.Get(id));
        }


        [HttpGet("{id:guid}/download")]
        public async Task<IActionResult> Download(Guid id)
        {
            var client = await _clientService.Get(id);

            string jsonClient = JsonConvert.SerializeObject(client.ToDTO());

            return File(Encoding.ASCII.GetBytes(jsonClient), "application/json", $"Export-{client.Name}.json");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientCreateUpdateRequestDTO clientDTO)
        {
            ValidationResult result = await _clientValidator.ValidateAsync(clientDTO);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return BadRequest(this.ModelState);
            }

            Client client = await _clientService.Add(clientDTO.FromDTO());

            return Ok(client.ToResponseDTO());
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClientCreateUpdateRequestDTO clientDTO)
        {
            ValidationResult result = await _clientValidator.ValidateAsync(clientDTO);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return BadRequest(this.ModelState);
            }
            await _clientService.Change(id, clientDTO.FromDTO());

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _clientService.Remove(id);

            return NoContent();
        }


        [HttpPost("{id:guid}/address")]
        public async Task<IActionResult> AddAddress(Guid id, [FromBody] AddressCreateUpdateRequestDTO addressDTO)
        {
            ValidationResult result = await _addressValidator.ValidateAsync(addressDTO);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return BadRequest(this.ModelState);
            }
            Address address = await _clientService.AddAddress(id, addressDTO.FromDTO());

            return Ok(address.ToResponseDTO());
        }
    }
}
