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
            builder.Services.AddHttpClient<ICarRepository, CarRepository>(client =>
            {
                client.BaseAddress = new Uri("http://3.97.115.6/api/");
            });
            builder.Services.AddHttpClient<IBookingRepository, BookingRepository>(client =>
            {
                client.BaseAddress = new Uri("http://3.97.115.6/api/"); 
            });
            builder.Services.AddHttpClient<ICarRentalRepository, CarRentalRepository>(client =>
            {
                client.BaseAddress = new Uri("http://3.97.115.6/api/");
            });



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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}