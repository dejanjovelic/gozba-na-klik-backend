using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateAsync([FromBody] Customer customer)
        {
            return Ok(await _customerService.CreateAsync(customer));
        }

        //GET api/customers/5
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByIdAsync(int customerId)
        {
            return Ok(await _customerService.GetByIdAsync(customerId));
        }


        //GET api/customers/5/allergens
        [HttpGet("{customerId}/allergens")]
        public async Task<IActionResult> GetAllCustomerAllergens(int customerId)
        {
            return Ok(await _customerService.GetAllCustomerAllergensAsync(customerId));
        }

        //PUT api/customers/5/allergens
        [HttpPut("{customerId}/allergens")]
        public async Task<IActionResult> UpdateCustomerAllergensAsync(int customerId, [FromBody] List<int> allergenIds)
        {
            return Ok(await _customerService.UpdateCustomerAllergensAsync(customerId, allergenIds));
        }


        //GET api/customers/5/addresses
        [HttpGet("{customerId}/addresses")]
        public async Task<IActionResult> GetAddressesAsync(int customerId)
        {
            return Ok(await _customerService.GetAddressesAsync(customerId));
        }

        [HttpPost("{customerId}/addresses")]
        public async Task<IActionResult> CreateAddressAsync(int customerId, [FromBody] Address address)
        {
            return Ok(await _customerService.CreateAddressAsync(customerId, address));
        }

        [HttpPut("{customerId}/addresses/{addressId}")]
        public async Task<IActionResult> UpdateAddressAsync(int customerId, int addressId, [FromBody] Address updatedAddress)
        {
            return Ok(await _customerService.UpdateAddressAsync(customerId, addressId, updatedAddress));
        }

        [HttpDelete("{customerId}/addresses/{addressId}")]
        public async Task<IActionResult> DeleteAddressAsync(int customerId, int addressId)
        {
            await _customerService.DeleteAddressAsync(customerId, addressId);
            return NoContent();
        }
    }
}