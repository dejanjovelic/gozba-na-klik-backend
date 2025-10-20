 using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Servises.IServices;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Servises
{
    public class AllergenService : IAllergenService
    {
        private readonly IAllergenRepository _allergenRepository;

        public AllergenService(IAllergenRepository allergenRepository)
        {
            _allergenRepository = allergenRepository;
        }

        public async Task<List<Allergen>> GetAllAsync()
        {
            return await _allergenRepository.GetAllAsync();
        }
    }
}
