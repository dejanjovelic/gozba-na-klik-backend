using gozba_na_klik_backend.Model;

namespace gozba_na_klik_backend.Servises.IServices
{
    public interface IAllergenService
    {
        Task<List<Allergen>> GetAllAsync();
        Task<List<Allergen>> GetAllSelectedAllergensAsync(List<int> allergenIds);
    }
}