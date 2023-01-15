using meal_plan_generator.Context.UnitofWork;
using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Repository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.ComponentModel;
using Food = meal_plan_generator.Models.MealPlan.Food;
using Nutrient = meal_plan_generator.Models.MealPlan.Nutrient;

namespace meal_plan_generator.Services
{
    public class Service : IService<MealPlan>
    {
        private readonly IUnitOfWork _uow;

        private MealPlan _mealPlan { get; set; }
        private Guid _guid { get; set; }
        private double MealScore { get; set; }
        private double NutrientScore { get; set; }

        private IList<Food> _foodList = new List<Food>();

        public Service(IUnitOfWork uow)
        {
            _uow = uow;
            _mealPlan = new MealPlan();
        }


        public void LoadNutrientData(string database)
        {
            // Load nutrient data from the specified database
            throw new NotImplementedException("TODO");
        }

        public async Task<MealPlan> GetNewMealPlanForFormAsync(Form nutrientFormData)
        {
            // Setup Variables
            var id = nutrientFormData.Id;
            var foodList = await _uow.FakeFoodsRepo.GetAllAsync();


            //_uow.FakeFoodsRepo.GetAllAsync();


            // Get 100 foods with the highest quantity
            foreach (var nutrient in nutrientFormData.Nutrients)
            {
                var top100Foods = foodList
                .Where(f => f.Nutrients.Any(foodNut => foodNut.Name == nutrient.Name))
                .OrderByDescending(f => f.Nutrients.FirstOrDefault(n => n.Name == nutrient.Name).Quantity)
                .Take(100).ToList();

                // Select a random food from the list
                var random = new Random();
                var index = random.Next(top100Foods.Count);
                var randomFood = top100Foods[index];
                _mealPlan.AddFood(randomFood);

                // Calculate the new MSCORE after adding the food to the meal plan
                float newMSCORE = CalculateMSCORE(_mealPlan);

                // Check if any nutrient exceeds its upper bound after adding the food
                //bool nutrientExceedsUB = CheckForExceededNutrient(newMSCORE);

                // If a nutrient exceeds its upper bound, remove the food and try again
                //if (nutrientExceedsUB)
                //{
                //    _mealPlan.removeFood(randomFood);

                //}
                //else
                //{
                //    // Otherwise, add the food to the meal plan
                //    _mealPlan.AddFood(randomFood);
                //}
            }

            return _mealPlan;

        }




        /*

        public float CalculateNutrientContent(Food food)
        {
            // Calculate the nutrient content of the specified food
            throw new NotImplementedException("TODO");
        }

        private bool CheckForExceededNutrient(float newMSCORE)
        {
            throw new NotImplementedException();
        }

        private FoundationFood SelectFood(ComponentId id)
        {
            // Use the USDA Food Data Central API to retrieve a list of foods that contain the highest amount of the specified nutrient
            var foodList = GetFoodsForNutrient(id);

            // Select a random food from the list
            var random = new Random();
            var index = random.Next(foodList.Count);
            return foodList[index];
        }

        private static List<FoundationFood> GetFoodsForNutrient(ComponentId componentId)
        {


            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Models", "USDA", "foods.json");
            Root? json = JsonConvert.DeserializeObject<Root>(File.ReadAllText(jsonFilePath));
            if (json != null && json.FoundationFoods != null)
            {
                int id = (int)componentId;
                List<FoundationFood> top100Foods = json.FoundationFoods
                .Where(f => f.FoodNutrients != null && f.FoodNutrients.Any(n => n.Nutrient.Id == id))
                .OrderByDescending(f => f.FoodNutrients.First(n => n.Nutrient.Id == id).Amount)
                .Take(100).ToList();

                int index = new Random().Next(top100Foods.Count());
                var randomFood = top100Foods[index];

                // Get nutient value
                var result = randomFood.FoodNutrients.Where(n => n.Nutrient.Id == id).First();
                string nutrient = $"{randomFood.Description} \nwith\t{result.Nutrient.Name}\t{result.Nutrient.Number} {result.Nutrient.UnitName}\trank: {result.Nutrient.Rank}";
                Console.WriteLine(nutrient);

                return top100Foods;
            }
            else
            {
                throw new NullReferenceException("Value cannot be null");
            }
        }

        public float CalculateMSCORE(MealPlan mp)
        {
            // Calculate MSCORE based on the current list of foods in the meal plan
            return mp.CalculateScore();

        }

        public MealPlan AddFoodsToMealPlan(List<Food> nutrients)
        {
            var mp = new MealPlan();
            foreach (var nutrient in nutrients)
            {
                // Select a random food from the list of 100 foods that contain the highest amount of the nutrient
                FoundationFood food = SelectFood(nutrient.ComponentId);

                // Calculate the new MSCORE after adding the food to the meal plan
                float newMSCORE = CalculateMSCORE(mp);

                // Check if any nutrient exceeds its upper bound after adding the food
                bool nutrientExceedsUB = CheckForExceededNutrient(newMSCORE);

                // If a nutrient exceeds its upper bound, remove the food and try again
                if (nutrientExceedsUB)
                {
                    mp.removeFood(food);

                }
                else
                {
                    // Otherwise, add the food to the meal plan
                    mp.AddFood(food);
                }
            }
            return mp;
        }

        public List<Food> GetDefaultNutrientList()
        {
            // Define nutrients list to consider when adding foods to the meal plan
            return new List<Food>
            {
                // this is the nutrient list from https://scholarworks.gvsu.edu/cgi/viewcontent.cgi?article=1068&context=oapsf_articles
                new Nutrient(ComponentId.Calcium_mg) { Name = ComponentId.Calcium_mg.ToString() },
                new Nutrient(ComponentId.Phosphorus_mg) { Name = ComponentId.Phosphorus_mg.ToString() },
                new Nutrient(ComponentId.Magnesium_mg) { Name = ComponentId.Magnesium_mg.ToString() },
                new Nutrient(ComponentId.Potassium_mg) { Name = ComponentId.Potassium_mg.ToString() },
                new Nutrient(ComponentId.Sodium_mg) { Name = ComponentId.Sodium_mg.ToString() },
                new Nutrient(ComponentId.Iron_mg) { Name = ComponentId.Iron_mg.ToString() },
                new Nutrient(ComponentId.Manganese_mg) { Name = ComponentId.Manganese_mg.ToString() },
                new Nutrient(ComponentId.Copper_mg) { Name = ComponentId.Copper_mg.ToString() },
                new Nutrient(ComponentId.Zinc_mg) { Name = ComponentId.Zinc_mg.ToString() },
                new Nutrient(ComponentId.Selenium_µg) { Name = ComponentId.Selenium_µg.ToString() },
                new Nutrient(ComponentId.VitaminA_IU) { Name = ComponentId.VitaminA_IU.ToString() },
                new Nutrient(ComponentId.Vitamin_C_Total_mg) { Name = ComponentId.Vitamin_C_Total_mg.ToString() },
                new Nutrient(ComponentId.VitaminE_AlphaTocopherol_mg) { Name = ComponentId.VitaminE_AlphaTocopherol_mg.ToString() },
                new Nutrient(ComponentId.VitaminK_Dihydrophylloquinone_µg) { Name = ComponentId.VitaminK_Dihydrophylloquinone_µg.ToString() },
                new Nutrient(ComponentId.Thiamin_mg) { Name = ComponentId.Thiamin_mg.ToString() },
                new Nutrient(ComponentId.Riboflavin_mg) { Name = ComponentId.Riboflavin_mg.ToString() },
                new Nutrient(ComponentId.Niacin_mg) { Name = ComponentId.Niacin_mg.ToString() },
                new Nutrient(ComponentId.PantothenicAcid_mg) { Name = ComponentId.PantothenicAcid_mg.ToString() },
                new Nutrient(ComponentId.FolateTotal_µg) { Name = ComponentId.FolateTotal_µg.ToString() },
            };
        }

        public void CreateMealPlan()
        {
            var mealPlan = new MealPlan() { FoundationFoods = new List<FoundationFood>() };
            List<Food> nutrients = GetDefaultNutrientList();
            AddFoodsToMealPlan(nutrients);

        }
        */

        public IEnumerable<MealPlan> GetAll()
        {
            throw new NotImplementedException();
        }

        public MealPlan GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(MealPlan entity)
        {
            throw new NotImplementedException();
        }

        public void Update(MealPlan entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(MealPlan entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public MealPlan AddFoodsToMealPlan(List<Food> nutrients)
        {
            throw new NotImplementedException();
        }

        public float CalculateMSCORE(MealPlan mp)
        {
            throw new NotImplementedException();
        }

        public float CalculateNutrientContent(Food food)
        {
            throw new NotImplementedException();
        }

        public void CreateMealPlan()
        {
            throw new NotImplementedException();
        }

        public List<Food> GetDefaultNutrientList()
        {
            throw new NotImplementedException();
        }
    }
}

