using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergensController : ControllerBase
    {
        private readonly AllergenRepository _allergenRepository;

        public AllergensController(AppDbContext context)
        {
            this._allergenRepository = new AllergenRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<Allergen> allergens = await _allergenRepository.GetAllAsync();
                return Ok(allergens);
            }
            catch (Exception)
            {

                return Problem("An error occured while fetching allergens.");
            }
        }
    }
}
