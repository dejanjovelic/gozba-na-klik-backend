using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using gozba_na_klik_backend.Services.IServices;
namespace gozba_na_klik_backend.Services.BackgroundServices
{
    public class OrderBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        
        public OrderBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) //radi dok se aplikacija ne zatvori
            {
                using var scope = _scopeFactory.CreateScope();
                var orderService = scope.ServiceProvider.GetService<IOrderService>();
                orderService.AssignOrderToCourierAsync();
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}
