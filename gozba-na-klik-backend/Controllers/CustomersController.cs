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
                return Ok(await _addressRepository.GetAddressesByCustomerIdAsync(customerId));
            }
            catch (Exception ex)
            {
                return Problem("An error occured while fetching addresses.");
            }
        }

    }
}    