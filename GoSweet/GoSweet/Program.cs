using GoSweet.Models;
using Microsoft.EntityFrameworkCore;
using Toolbelt.Extensions.DependencyInjection;
namespace GoSweet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ShopwebContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("shopweb")));

            //Add  Http Session
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".GoSweet.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //±Ò¥Îhttp session
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}