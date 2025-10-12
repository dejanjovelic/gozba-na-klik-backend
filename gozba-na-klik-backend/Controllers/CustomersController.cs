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
        private readonly AddressRepository _addressRepository;

        public CustomersController(AppDbContext context)
        {
            _customerRepository = new CustomerRepository(context);
            _allergenRepository = new AllergenRepository(context);
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

        //GET api/customers/5
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByIdAsync(int customerId)
        {
            try
            {
                Customer customer = await _customerRepository.GetByIdAsync(customerId);
                if (customer == null)
                {
                    return NotFound($"Customer with ID{customerId} not found.");
                }
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


        //GET api/customers/5/addresses
        [HttpGet("{customerId}/addresses")]
        public async Task<IActionResult> GetAddressesAsync(int customerId)
        {
            try
            {
                Customer customer = await _customerRepository.GetByIdAsync(customerId);
                if (customer == null)
                {
                    return NotFound($"Customer with ID: {customerId} not found.");
                }
                return Ok(await _addressRepository.GetByCustomerIdAsync(customerId));
            }
                catch (Exception ex)
            {
                return Problem("An error occured while fetching addresses.");
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

                List<Allergen> allergens = await _allergenRepository.GetAllSelectedAllergensAsync(allergenIds);
                 
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
                Customer customer = await _customerRepository.GetByIdAsync(customerId);
                if (customer == null)
                {
                    return NotFound($"Customer with ID: {customerId} not found.");
                }

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
                Customer customer = await _customerRepository.GetByIdAsync(customerId);
                if (customer == null)
                {
                    return NotFound($"Customer with ID: {customerId} not found.");
                }

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
                Customer customer = await _customerRepository.GetByIdAsync(customerId);
                if (customer == null)
                {
                    return NotFound($"Customer with ID: {customerId} not found.");
                }

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