using gozba_na_klik_backend.Exceptions;
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Servises.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Allergen>> GetAllSelectedAllergensAsync(List<int> allergenIds)
        {
            List<Allergen>  allergens = await _allergenRepository.GetAllSelectedAllergensAsync(allergenIds);
            if (allergens.Count != allergenIds.Count)
            {
                throw new BadRequestException("One or more allergens do not exist.");
            }
            return allergens;
        }
    }
}
