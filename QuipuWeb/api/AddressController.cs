using Application.Service;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using QuipuWeb.Dto;
using QuipuWeb.Extension;

namespace QuipuWeb.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly IAddressService _addressService;
        private readonly IValidator<AddressCreateUpdateRequestDTO> _addressValidator;

        public AddressController(IAddressService addressService, IValidator<AddressCreateUpdateRequestDTO> addressValidator)
        {
            _addressService = addressService;
            _addressValidator = addressValidator;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _addressService.Get(id));
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AddressCreateUpdateRequestDTO addressDTO)
        {
            ValidationResult result = await _addressValidator.ValidateAsync(addressDTO);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return BadRequest(this.ModelState);
            }
            await _addressService.Change(id, addressDTO.FromDTO());

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _addressService.Remove(id);

            return NoContent();
        }
    }
}
