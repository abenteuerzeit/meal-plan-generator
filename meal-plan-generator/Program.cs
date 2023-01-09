using meal_plan_generator.Data;
using meal_plan_generator.Data.Repository;
using meal_plan_generator.Context;
using meal_plan_generator.Context.UnitofWork;
using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using meal_plan_generator.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace meal_plan_generator
{
    public class Program
    {
        private static IConfiguration? Configuration;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();

            // Add services to the container.
            var services = builder.Services;

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            //services.AddDbContext<MealPlanDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository<Form>, Repository<Form>>();
            services.AddScoped<IRepository<Food>, Repository<Food>>();
            services.AddScoped<IRepository<MealPlan>, Repository<MealPlan>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            ILoggerFactory loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

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