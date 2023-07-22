using GoSweet.Hubs;
using GoSweet.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("shopwebConnstring")));
            builder.Services.AddHttpContextAccessor();

            //Add  Http Session
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".GoSweet.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;
            });

            //Add Singalr 
            builder.Services.AddSignalR();

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

            //Singalr Path
            app.MapHub<ChatHub>("/chatHub");

            app.Run();
        }
    }
}