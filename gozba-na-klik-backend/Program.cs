
using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Model.IRepositories;
using gozba_na_klik_backend.Repository;
using gozba_na_klik_backend.Services;
using gozba_na_klik_backend.Services.IServices;
using gozba_na_klik_backend.Services.IServices;
using gozba_na_klik_backend.Settings;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using gozba_na_klik_backend.Services.BackgroundServices;

namespace gozba_na_klik_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowAnyOrigin();
                    });
            });

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            builder.Services.AddTransient<ExceptionHandlingMiddleware>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<IAllergenService, AllergenService>();
            builder.Services.AddScoped<IAllergenRepository, AllergenRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICourierRepository, CourierRepository>();
            builder.Services.AddScoped<ICourierService, CourierService>();
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();
            builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IMealService, MealService>();
            builder.Services.AddScoped<IMealRepository, MealRepository>();
            builder.Services.AddHostedService<OrderBackgroundService>();
            builder.Services.AddHostedService<CourierBackgroundService>();
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MealProfile>();
                cfg.AddProfile<OrderProfile>();
            });

            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        
            var app = builder.Build();
            app.UseCors("AllowAllOrigins");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}
