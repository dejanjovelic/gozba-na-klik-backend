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
        //PUT api/customers/customerId/allergens
        [HttpPut("{customersId}/allergens")]
        public async Task<IActionResult> UpdateCustomerAllergensAsync(int customersId, [FromBody] List<int> allergenIds)
        {
            try
            {
                Customer customer = await _customerRepository.GetByIdAsync(customersId);
                if (customer == null)
                {
                    return NotFound($"Custome with ID {customersId} not found.");
                }

                List<Allergen> allergens = await _allergenRepository.GetAllCustomersAllergentsAsync(allergenIds);

                if (allergens.Count != allergenIds.Count)
                    return BadRequest("One or more allergens do not exist.");

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