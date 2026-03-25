using AutoMapper;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Services.DTOs;
using gozba_na_klik_backend.Services.DTOs.AuthDtos;
using gozba_na_klik_backend.Services.Exceptions;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security;


namespace gozba_na_klik_backend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAllergenService _allergenService;
        private readonly IAddressRepository _addressRepository;
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;


        public CustomerService(
            ICustomerRepository customerRepository,
            IAllergenService allergenService,
            IAddressRepository addressRepository,
            ICreditCardRepository creditCardRepository,
            IAuthService authService,
            IMapper mapper
            )
        {
            _customerRepository = customerRepository;
            _allergenService = allergenService;
            _addressRepository = addressRepository;
            _creditCardRepository = creditCardRepository;
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
            ValidateOwnership(customerId, ownerId);

            Customer customer = await GetCustomerOrThrowAsync(customerId);
            return customer;
        }


        public async Task<List<Allergen>> GetAllCustomerAllergensAsync(string customerId, string? ownerId)
        {
            ValidateOwnership(customerId, ownerId);
            Customer customer = await GetCustomerOrThrowAsync(customerId);

            return customer.Allergens;
        }


        public async Task<List<Address>> GetAddressesAsync(string customerId, string? ownerId)
        {
            ValidateOwnership(customerId, ownerId);
            Customer customer = await GetCustomerOrThrowAsync(customerId);

            return await _addressRepository.GetByCustomerIdAsync(customerId);
        }


        public async Task<Customer> UpdateCustomerAllergensAsync(string customerId, List<int> allergenIds, string? ownerId)
        {
            ValidateOwnership(customerId, ownerId);

            Customer customer = await GetCustomerOrThrowAsync(customerId);
            List<Allergen> allergens = await _allergenService.GetAllSelectedAllergensAsync(allergenIds);
            Customer updatedCustomer = await _customerRepository.UpdateCustomerAllergensAsync(customer, allergens);

            return updatedCustomer;
        }


        public async Task<Address> CreateAddressAsync(string customerId, NewAddressDto updatedAddress, string? ownerId)
        {
            ValidateOwnership(customerId, ownerId);

            if (updatedAddress == null)
            {
                throw new BadRequestException("Invalid data.");
            }

            Customer customer = await GetCustomerOrThrowAsync(customerId);

            Address address = _mapper.Map<Address>(updatedAddress);
            address.CustomerId = customerId;

            return await _addressRepository.CreateAsync(address);
        }

        public async Task<List<CreditCardResponseDto>> GetCreditCardsAsync(string customerId, string? ownerId)
        {
            ValidateOwnership(customerId, ownerId);
            Customer customer = await GetCustomerOrThrowAsync(customerId);
            return customer.CreditCards.Select(c => _mapper.Map<CreditCardResponseDto>(c)).ToList();
        }

        public async Task<CreditCardResponseDto> CreateCreditCardAsync(string customerId, NewCreditCardDto newCreditCard, string? ownerId)
        {
            ValidateOwnership(customerId, ownerId);

            if (newCreditCard == null)
            {
                throw new BadRequestException("Invalid data.");
            }

            CreditCard creditCard = _mapper.Map<CreditCard>(newCreditCard);
            creditCard.OwnerId = customerId;

            Customer customer = await GetCustomerOrThrowAsync(customerId);

            var created = await _creditCardRepository.CreateAsync(creditCard);
            return _mapper.Map<CreditCardResponseDto>(created);
        }

        public async Task<CreditCardResponseDto> UpdateCreditCardAsync(string customerId, int creditCardId, NewCreditCardDto updatedCreditCard, string? ownerId)
        {
            ValidateOwnership(customerId, ownerId);
            ValidateCreditCardUpdateData(creditCardId, updatedCreditCard);

            Customer customer = await GetCustomerOrThrowAsync(customerId);
            CreditCard existingCreditCard = await GetCreditCardOrThrowAsync(creditCardId);

            ValidateOwnership(customer.Id, existingCreditCard.OwnerId);

            existingCreditCard.Bank = updatedCreditCard.Bank;
            existingCreditCard.CardNumber = updatedCreditCard.CardNumber;
            existingCreditCard.Brand = updatedCreditCard.Brand;
            existingCreditCard.CardHolderFirstName = updatedCreditCard.CardHolderFirstName;
            existingCreditCard.CardHolderLastName = updatedCreditCard.CardHolderLastName;

            var updated = await _creditCardRepository.UpdateAsync(existingCreditCard);
            return _mapper.Map<CreditCardResponseDto>(updated);
        }



        public async Task DeleteCreditCardAsync(string customerId, int creditCardId, string? ownerId)
        {
            ValidateOwnership(customerId, ownerId);

            Customer customer = await GetCustomerOrThrowAsync(customerId);
            CreditCard creditCard = await GetCreditCardOrThrowAsync(creditCardId);

            ValidateOwnership(creditCard.OwnerId, customer.Id);

            await _creditCardRepository.DeleteAsync(creditCard);
        }


        public async Task<Address> UpdateAddressAsync(string customerId, int addressId, NewAddressDto updatedAddress, string? ownerId)
        {
            ValidateInputData(customerId, addressId, updatedAddress, ownerId);

            Customer customer = await GetCustomerOrThrowAsync(customerId);
            Address existingAddress = await GetAddressOrThrowAsync(addressId);

            ValidateOwnership(existingAddress.CustomerId, customer.Id);
            _mapper.Map(updatedAddress, existingAddress);
            existingAddress.CustomerId = customerId;

            return await _addressRepository.UpdateAsync(existingAddress);
        }

        

        public async Task DeleteAddressAsync(string customerId, int addressId, string? ownerId)
        {
            ValidateOwnership(customerId, ownerId);

            Customer customer = await GetCustomerOrThrowAsync(customerId);
            Address address = await GetAddressOrThrowAsync(addressId);

            ValidateOwnership(customer.Id, address.CustomerId);

            await _addressRepository.DeleteAsync(address);
        }


        private async Task<Address> GetAddressOrThrowAsync(int addressId)
        {
            Address address = await _addressRepository.GetByIdAsync(addressId);

            if (address == null)
            {
                throw new NotFoundException($"Adress with ID: {addressId} not found.");
            }

            return address;
        }

        private async Task<Customer> GetCustomerOrThrowAsync(string customerId)
        {
            Customer customer = await _customerRepository.GetByIdAsync(customerId);

            if (customer == null)
            {
                throw new NotFoundException($"Customer with ID: {customerId} not found.");
            }

            return customer;
        }

        private static void ValidateInputData(string customerId, int addressId, NewAddressDto updatedAddress, string? ownerId)
        {
            ValidateOwnership(customerId, ownerId);

            if (updatedAddress == null)
            {
                throw new BadRequestException("Invalid Address data.");
            }

            if (addressId != updatedAddress.Id)
            {
                throw new BadRequestException("Address ID mismatch");
            }

        }

        private static void ValidateOwnership(string customerId, string? ownerId)
        {
            if (customerId != ownerId)
            {
                throw new ForbiddenException("You do not have permission to perform this action.");
            }
        }

        private async Task<CreditCard> GetCreditCardOrThrowAsync(int creditCardId)
        {
            CreditCard existing = await _creditCardRepository.GetByIdAsync(creditCardId);
            if (existing == null)
            {
                throw new NotFoundException($"CreditCard with ID: {creditCardId} not found.");
            }

            return existing;
        }

        private static void ValidateCreditCardUpdateData(int creditCardId, NewCreditCardDto updatedCreditCard)
        {
            if (updatedCreditCard == null)
            {
                throw new BadRequestException("Invalid CreditCard data.");
            }

            if (creditCardId != updatedCreditCard.Id)
            {
                throw new BadRequestException("CreditCard ID mismatch");
            }
        }
    }
}