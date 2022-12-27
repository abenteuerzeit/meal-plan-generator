using meal_plan_generator.Models.USDA;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace meal_plan_generator
{
    public class Program
    {
        private static IConfiguration? Configuration;

        public static void Main(string[] args)
        {
            #region Picu put a breakpoint at randomfood
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Models", "USDA", "foods.json");
            Root? myDeserializedClass = JsonConvert.DeserializeObject<Root>(File.ReadAllText(jsonFilePath));
            if (myDeserializedClass != null && myDeserializedClass.FoundationFoods != null)
            {
                int id = 1003;
                List<FoundationFood> top100Foods = myDeserializedClass.FoundationFoods
                .Where(f => f.FoodNutrients != null && f.FoodNutrients.Any(n => n.Nutrient.Id == id))
                .OrderByDescending(f => f.FoodNutrients.First(n => n.Nutrient.Id == id).Amount)
                .Take(100).ToList();

                int index = new Random().Next(top100Foods.Count());
                var randomFood = top100Foods[index];
            }
            #endregion

            var builder = WebApplication.CreateBuilder(args);

            Configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddControllersWithViews();

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