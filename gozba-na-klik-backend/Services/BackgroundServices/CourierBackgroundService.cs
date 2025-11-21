using gozba_na_klik_backend.Services.IServices;
namespace gozba_na_klik_backend.Services.BackgroundServices
{
    public class CourierBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public CourierBackgroundService(IServiceScopeFactory scopeFactory) 
        {
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var courierService = scope.ServiceProvider.GetService<ICourierService>();
                await courierService.UpdateCourierStatusAsync();
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}
