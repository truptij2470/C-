using Microsoft.EntityFrameworkCore;
using WebApplicationTrupi.Models;

namespace WebApplicationTrupi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BooksContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("BooksContext")));

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Bookstables}/{action=Index}/{id?}");

            app.Run();
        }
    }
}