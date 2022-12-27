using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models.USDA;
using meal_plan_generator.Repository;
using meal_plan_generator.UnitofWork;
using Newtonsoft.Json;
using Nutrient = meal_plan_generator.Models.MealPlan.Nutrient;

namespace meal_plan_generator.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;

        public Service(IUnitOfWork<TEntity> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private bool CheckForExceededNutrient(decimal newMSCORE)
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



        public IEnumerable<TEntity> GetAll()
        {
            return _unitOfWork.Repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _unitOfWork.Repository.GetById(id);
        }

        public void Add(TEntity entity)
        {
            _unitOfWork.Repository.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.Repository.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _unitOfWork.Repository.Remove(entity);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }


        public decimal CalculateMSCORE(MealPlan mp)
        {
            // Calculate MSCORE based on the current list of foods in the meal plan
            return mp.CalculateScore();

        }


        public MealPlan AddFoodsToMealPlan(List<Nutrient> nutrients)
        {
            var mp = new MealPlan();
            foreach (var nutrient in nutrients)
            {
                // Select a random food from the list of 100 foods that contain the highest amount of the nutrient
                FoundationFood food = SelectFood(nutrient.Id);

                // Calculate the new MSCORE after adding the food to the meal plan
                decimal newMSCORE = CalculateMSCORE(mp);

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

        public List<Nutrient> GetDefaultNutrientList()
        {
            // Define nutrients list to consider when adding foods to the meal plan
            return new List<Nutrient>
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
            List<Nutrient> nutrients = GetDefaultNutrientList();
            AddFoodsToMealPlan(nutrients);

        }
    }
}

