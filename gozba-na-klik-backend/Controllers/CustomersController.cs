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
        private readonly AllergenRepository _allergenRepository;

        public CustomersController(AppDbContext context)
        {
            _customerRepository = new CustomerRepository(context);
            _allergenRepository = new AllergenRepository(context);
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

        //GET api/customers/5
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByIdAsync(int customerId)
        {
            try
            {
                Customer customer = await _customerRepository.GetByIdAsync(customerId);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return Problem("An error occured while fetching customer.");
            }
        }

        //GET api/customers/5/allergens
        [HttpGet("{customerId}/allergens")]
        public async Task<IActionResult> GetAllCustomerAllergens(int customerId)
        {
            try
            {
                Customer customer = await _customerRepository.GetByIdAsync(customerId);
                if (customer == null)
                {
                    return NotFound($"An Cutomer with ID{customerId} not found.");
                }
                return Ok(customer.Allergens);
            }
            catch (Exception ex)
            {
                return Problem("An error occured while fetching Customers allergens.");
            }

        }

        //PUT api/customers/5/allergens
        [HttpPut("{customerId}/allergens")]
        public async Task<IActionResult> UpdateCustomerAllergensAsync(int customerId, [FromBody] List<int> allergenIds)
        {
            try
            {
                Customer customer = await _customerRepository.GetByIdAsync(customerId);
                if (customer == null)
                {
                    return NotFound($"Customer with ID {customerId} not found.");
                }

                List<Allergen> allergens = await _allergenRepository.GetAllSelectedAllergentsAsync(allergenIds);

                if (allergens.Count != allergenIds.Count)
                {
                    return BadRequest("One or more allergens do not exist.");
                }
                    

                Customer updatedCustomer = await _customerRepository.UpdateCustomerAllergensAsync(customer, allergens);
                return Ok(updatedCustomer);
            }
            catch (Exception ex)
            {
                return Problem("An error occured while updating customer allergens.");
            }


        }

    }
}