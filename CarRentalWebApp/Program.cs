using CarRentalWebApp.MockRepositories;
using CarRentalWebApp.Repositories;

namespace CarRentalWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Conditionally add HttpClient for ICarRepository or use MockCarRepository
            if (builder.Environment.IsDevelopment())
            {
                // Use mock repository in development
                builder.Services.AddScoped<ICarRepository, MockCarRepository>();
                builder.Services.AddScoped<IBookingRepository, MockBookingRepository>();
                builder.Services.AddScoped<ICarRentalRepository, MockCarRentalRepository>();

            }
            else
            {
                builder.Services.AddHttpClient<ICarRepository, CarRepository>(client =>
                {
                    client.BaseAddress = new Uri("https://your-car-rental-api/"); // Replace with actual API base URL
                });
                builder.Services.AddHttpClient<IBookingRepository, BookingRepository>(client =>
                {
                    client.BaseAddress = new Uri("https://your-booking-api/"); // Replace with actual API base URL 
                });
                builder.Services.AddHttpClient<ICarRentalRepository, CarRentalRepository>(client =>
                {
                    client.BaseAddress = new Uri("https://your-booking-api/"); // Replace with actual API base URL
                });
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Use MockApiMiddleware in development environment
            if (app.Environment.IsDevelopment())
            {
                app.UseMiddleware<MockApiMiddleware>();
            }

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}