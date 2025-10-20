using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Servises.IServices
{
    public interface ICustomerService : ICustomerAddresseService, ICustomerAllergenService
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> GetByIdAsync(int customerId);
    }
}