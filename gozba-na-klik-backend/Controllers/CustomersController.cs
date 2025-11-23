using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService service)
        {
            _customerService = service;

        }

        //POST api/customers
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RegistrationDto registrationDto)
        {
            return Ok(await _customerService.CreateAsync(registrationDto));
        }

        //GET api/customers/5
        [Authorize(Roles = "Customer")]
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByIdAsync(string customerId)
        {
            string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _customerService.GetByIdAsync(customerId, ownerId));
        }


        //GET api/customers/5/allergens
        [Authorize(Roles = "Customer")]
        [HttpGet("{customerId}/allergens")]
        public async Task<IActionResult> GetAllCustomerAllergens(string customerId)
        {
            string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _customerService.GetAllCustomerAllergensAsync(customerId, ownerId));
        }

        //PUT api/customers/5/allergens
        [Authorize(Roles = "Customer")]
        [HttpPut("{customerId}/allergens")]
        public async Task<IActionResult> UpdateCustomerAllergensAsync(string customerId, [FromBody] List<int> allergenIds)
        {
            string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _customerService.UpdateCustomerAllergensAsync(customerId, allergenIds, ownerId));
        }


        //GET api/customers/5/addresses
        [Authorize(Roles = "Customer")]
        [HttpGet("{customerId}/addresses")]
        public async Task<IActionResult> GetAddressesAsync(string customerId)
        {
            string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _customerService.GetAddressesAsync(customerId, ownerId));
        }

        [Authorize(Roles = "Customer")]
        [HttpPost("{customerId}/addresses")]
        public async Task<IActionResult> CreateAddressAsync(string customerId, [FromBody] NewAddressDto newAddress)
        {
            string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _customerService.CreateAddressAsync(customerId, newAddress, ownerId));
        }

        [Authorize(Roles = "Customer")]
        [HttpPut("{customerId}/addresses/{addressId}")]
        public async Task<IActionResult> UpdateAddressAsync(string customerId, int addressId, [FromBody] NewAddressDto updatedAddress)
        {
            string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _customerService.UpdateAddressAsync(customerId, addressId, updatedAddress, ownerId));
        }

        [Authorize(Roles = "Customer")]
        [HttpDelete("{customerId}/addresses/{addressId}")]
        public async Task<IActionResult> DeleteAddressAsync(string customerId, int addressId)
        {
            string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _customerService.DeleteAddressAsync(customerId, addressId, ownerId);
            return NoContent();
        }
    }
}