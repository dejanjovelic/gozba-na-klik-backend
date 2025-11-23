
namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IMealRepository
    {
        IQueryable<Meal> GetAll();
        Task<List<Meal>> GetAllSelectedAsync(List<int> mealsIds);
    }
}
