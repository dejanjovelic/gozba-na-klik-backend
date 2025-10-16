using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Exceptions;
using Microsoft.AspNetCore.Mvc;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Servises.IServices;

namespace gozba_na_klik_backend.Servises
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAllergenRepository _allergenRepository; //treba prebaciti na Iterface
        private readonly IAddressRepository _addressRepository;

        public CustomerService(ICustomerRepository customerRepository, IAllergenRepository allergenRepository, IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _allergenRepository = allergenRepository;
            _addressRepository = addressRepository;
        }
        public async Task<Customer> CreateAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new BadRequestException("Invalid data.");
            }

            return await _customerRepository.CreateAsync(customer);
        }
        public async Task<Customer> GetByIdAsync(int customerId)
        {
            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID{customerId} not found.");
            }
            return customer;
        }

        public async Task<List<Allergen>> GetAllCustomerAllergensAsync(int customerId)
        {
            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID: {customerId} not found.");
            }
            return customer.Allergens;
        }

        public async Task<List<Address>> GetAddressesAsync(int customerId)
        {
            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID: {customerId} not found.");
            }
            return await _addressRepository.GetByCustomerIdAsync(customerId);
        }

        public async Task<Customer> UpdateCustomerAllergensAsync(int customerId, List<int> allergenIds)
        {
            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID {customerId} not found.");
            }

            List<Allergen> allergens = await _allergenRepository.GetAllSelectedAllergensAsync(allergenIds);

            if (allergens.Count != allergenIds.Count)
            {
                throw new BadRequestException("One or more allergens do not exist.");
            }

            Customer updatedCustomer = await _customerRepository.UpdateCustomerAllergensAsync(customer, allergens);
            return updatedCustomer;
        }

        public async Task<Address> CreateAddressAsync(int customerId, Address address)
        {
            if (address == null)
            {
                throw new BadRequestException("Invalid data.");
            }
            address.CustomerId = customerId;

            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID: {customerId} not found.");
            }

            return await _addressRepository.CreateAsync(address);
        }


        public async Task<Address> UpdateAddressAsync(int customerId, int addressId, Address updatedAddress)
        {
            if (addressId != updatedAddress.Id)
            {
                throw new BadRequestException("Address ID mismatch");
            }
            else if (updatedAddress == null)
            {
                throw new BadRequestException("Invalid Address data.");
            }

            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID: {customerId} not found.");
            }

            Address existingAddress = await _addressRepository.GetByIdAsync(addressId);

            if (existingAddress == null)
            {
                throw new NotFoundException($"Address with ID: {addressId} not found.");
            }

            existingAddress.CustomerId = customerId;
            existingAddress.Street = updatedAddress.Street;
            existingAddress.StreetNumber = updatedAddress.StreetNumber;
            existingAddress.City = updatedAddress.City;
            existingAddress.ZipCode = updatedAddress.ZipCode;

            return await _addressRepository.UpdateAsync(existingAddress);
        }

        public async Task DeleteAddressAsync(int customerId, int addressId)
        {
            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID: {customerId} not found.");
            }

            bool result = await _addressRepository.DeleteAsync(addressId);

            if (!result)
            {
                throw new NotFoundException($"Address with ID: {addressId} not found");
            }
        }

    }

}
