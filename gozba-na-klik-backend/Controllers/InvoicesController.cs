using gozba_na_klik_backend.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace gozba_na_klik_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        //GET api/invoices/invoiceId
        [Authorize(Roles = "Customer")]
        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetByIdAsync(string invoiceId)
        {
            string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _invoiceService.GetByIdAsync(invoiceId, ownerId));
        }
    }
}
