using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergensController : ControllerBase
    {
        private readonly IAllergenService _allergenService;

        public AllergensController(IAllergenService allergenService)
        {
            this._allergenService = allergenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _allergenService.GetAllAsync());
        }
    }
}
