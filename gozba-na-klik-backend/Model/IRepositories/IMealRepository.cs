
namespace gozba_na_klik_backend.Model.IRepositories
{
    public interface IMealRepository
    {
        IQueryable<Meal> GetAll();
    }
}
