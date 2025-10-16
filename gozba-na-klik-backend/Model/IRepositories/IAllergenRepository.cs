using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IAllergenRepository
    {
        Task<List<Allergen>> GetAllAsync();
        Task<List<Allergen>> GetAllSelectedAllergensAsync(List<int> allergenIds);
        Task<Allergen> GetbyIdAsync(int allergenId);
    }
}