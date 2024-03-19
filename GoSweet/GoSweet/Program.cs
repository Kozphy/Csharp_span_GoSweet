using GoSweet.Hubs;
using GoSweet.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Toolbelt.Extensions.DependencyInjection;

namespace GoSweet
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // add Logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();


            // Add services to the container.
            // Configuration
            ConfigurationManager configuration = builder.Configuration;

            builder.Services.AddControllersWithViews();

            // mssql
            builder
                .Services
                .AddDbContext<ShopwebContext>(
                    options =>
                        options.UseSqlServer(
                            builder.Configuration.GetConnectionString("shopwebConnstring")
                        )
                );

            // HttpContext encapsulates all information about an individual HTTP request and response.
            builder.Services.AddHttpContextAccessor();

            // Add Identity Service
            //builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequiredLength = 5;
            //}).AddEntityFrameworkStores<ShopwebContext>()
            ////    .AddDefaultTokenProviders();


            //Add Http Session
            builder
                .Services
                .AddSession(options =>
                {
                    options.Cookie.Name = ".GoSweet.Session";
                    options.IdleTimeout = TimeSpan.FromMinutes(30);
                    options.Cookie.IsEssential = true;
                });

            //Add Singalr
            builder.Services.AddSignalR();

            // add swagger 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add power bi
            var app = builder.Build();

            // swagger
            app.UseSwagger();
            app.UseSwaggerUI();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //�ҥ�http session
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            //Singalr Path
            app.MapHub<ChatHub>("/chatHub");

            app.Run();
        }
    }
}
