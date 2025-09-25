using Microsoft.EntityFrameworkCore;

namespace gozba_na_klik_backend.Model
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
    }
}
