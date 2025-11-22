using AutoMapper;
using gozba_na_klik_backend.DTOs;
using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security;


namespace gozba_na_klik_backend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAllergenService _allergenService;
        private readonly IAddressRepository _addressRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;


        public CustomerService(
            ICustomerRepository customerRepository,
            IAllergenService allergenService,
            IAddressRepository addressRepository,
            IAuthService authService,
            IMapper mapper
            )
        {
            _customerRepository = customerRepository;
            _allergenService = allergenService;
            _addressRepository = addressRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<string> CreateAsync(RegistrationDto registrationDto)
        {
            AuthResponseDto authResponseDto = await _authService.RegisterUserAsync(registrationDto, "Customer");

            Customer customer = new Customer { Id = authResponseDto.AplicationUserId };

            await _customerRepository.CreateAsync(customer);

            return authResponseDto.Token;
        }

       
        public async Task<Customer> GetByIdAsync(string customerId, string? ownerId)
        {
            if (customerId != ownerId) 
            {
                throw new ForbiddenException("You do not have permission to perform this action.");
            }

            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID{customerId} not found.");
            }
            return customer;
        }

       
        public async Task<List<Allergen>> GetAllCustomerAllergensAsync(string customerId, string? ownerId)
        {
            if (customerId != ownerId)
            {
                throw new ForbiddenException("You do not have permission to perform this action.");
            }

            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID: {customerId} not found.");
            }
            return customer.Allergens;
        }

       
        public async Task<List<Address>> GetAddressesAsync(string customerId, string? ownerId)
        {
            if (customerId != ownerId)
            {
                throw new ForbiddenException("You do not have permission to perform this action.");
            }

            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID: {customerId} not found.");
            }
            return await _addressRepository.GetByCustomerIdAsync(customerId);
        }

    
        public async Task<Customer> UpdateCustomerAllergensAsync(string customerId, List<int> allergenIds, string? ownerId)
        {
            if (customerId != ownerId)
            {
                throw new ForbiddenException("You do not have permission to perform this action.");
            }

            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID {customerId} not found.");
            }

            List<Allergen> allergens = await _allergenService.GetAllSelectedAllergensAsync(allergenIds);

            Customer updatedCustomer = await _customerRepository.UpdateCustomerAllergensAsync(customer, allergens);
            return updatedCustomer;
        }

       
        public async Task<Address> CreateAddressAsync(string customerId, NewAddressDto updatedAddress, string? ownerId)
        {
            if (customerId != ownerId)
            {
                throw new ForbiddenException("You do not have permission to perform this action.");
            }

            if (updatedAddress == null)
            {
                throw new BadRequestException("Invalid data.");
            }

            Address address = _mapper.Map<Address>(updatedAddress);

            address.CustomerId = customerId;

            Customer customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID: {customerId} not found.");
            }

            return await _addressRepository.CreateAsync(address);
        }

       
        public async Task<Address> UpdateAddressAsync(string customerId, int addressId, NewAddressDto updatedAddress, string? ownerId)
        {
            ValidateInputData(customerId, addressId, updatedAddress, ownerId);

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

            UpdateExistingAddressData(customerId, updatedAddress, existingAddress);

            return await _addressRepository.UpdateAsync(existingAddress);
        }

        private static void UpdateExistingAddressData(string customerId, NewAddressDto updatedAddress, Address existingAddress)
        {
            existingAddress.CustomerId = customerId;
            existingAddress.Street = updatedAddress.Street;
            existingAddress.StreetNumber = updatedAddress.StreetNumber;
            existingAddress.City = updatedAddress.City;
            existingAddress.ZipCode = updatedAddress.ZipCode;
        }

        private static void ValidateInputData(string customerId, int addressId, NewAddressDto updatedAddress, string? ownerId)
        {
            if (customerId != ownerId)
            {
                throw new ForbiddenException("You do not have permission to perform this action.");
            }

            if (addressId != updatedAddress.Id)
            {
                throw new BadRequestException("Address ID mismatch");
            }
            else if (updatedAddress == null)
            {
                throw new BadRequestException("Invalid Address data.");
            }
        }

        public async Task DeleteAddressAsync(string customerId, int addressId, string? ownerId)
        {
            if (customerId != ownerId)
            {
                throw new ForbiddenException("You do not have permission to perform this action.");
            }

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
