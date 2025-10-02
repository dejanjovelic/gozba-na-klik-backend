using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;
        private readonly AddressRepository _addressRepository;

        public CustomersController(AppDbContext context) 
        {
            _customerRepository = new CustomerRepository(context);
            _addressRepository = new AddressRepository(context);
        }

        //POST api/customers
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                await _customerRepository.CreateAsync(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return Problem("An error occured while creating Customer.");
            }

        }

        [HttpGet("{customerId}/addresses")]
        public async Task<IActionResult> GetAddressesAsync(int customerId)
        {
            try
            {
                return Ok(await _addressRepository.GetByCustomerIdAsync(customerId));
            }
            catch (Exception ex)
            {
                return Problem("An error occured while fetching addresses.");
            }
        }

        [HttpPost("{customerId}/addresses")]
        public async Task<IActionResult> CreateAddressAsync(int customerId, [FromBody] Address address)
        {
            if (address == null)
            {
                return BadRequest("Invalid data.");
            }

            address.CustomerId = customerId;

            try
            {
                await _addressRepository.CreateAsync(address);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return Problem("An error occured while creating address.");
            }
        }

        [HttpPut("{customerId}/addresses/{addressId}")]
        public async Task<IActionResult> UpdateAddressAsync(int customerId, int addressId, [FromBody] Address updatedAddress)
        {
            if (updatedAddress == null || addressId != updatedAddress.Id)
            {
                return BadRequest("Address ID mismatch");
            }

            try
            {
                Address existingAddress = await _addressRepository.GetByIdAsync(addressId);

                if (existingAddress == null)
                {
                    return NotFound($"Address with ID: {addressId} not found.");
                }

                existingAddress.CustomerId = customerId;
                existingAddress.Street = updatedAddress.Street;
                existingAddress.StreetNumber = updatedAddress.StreetNumber;
                existingAddress.City = updatedAddress.City;
                existingAddress.ZipCode = updatedAddress.ZipCode;
            
                await _addressRepository.UpdateAsync(existingAddress);
                return Ok(existingAddress);
            }
            catch (Exception ex)
            {
                return Problem("An error occured while updating address.");
            }
        }

        [HttpDelete("{customerId}/addresses/{addressId}")]
        public async Task<IActionResult> DeleteAddressAsync(int customerId, int addressId)
        {
            try
            {
                bool result = await _addressRepository.DeleteAsync(addressId);

                if (!result)
                {
                    return NotFound($"Address with ID: {addressId} not found");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"An error occured while deleting Address with ID: {addressId}");
            }
        }

    }
}    