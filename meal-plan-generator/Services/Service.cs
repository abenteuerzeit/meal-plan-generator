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

        private bool CheckForExceededNutrient(double newMSCORE)
        {
            throw new NotImplementedException();
        }

        private Food SelectFood(Nutrient nutrient)
        {
            // Use the USDA Food Data Central API to retrieve a list of foods that contain the highest amount of the specified nutrient
            var foodList = GetFoodsForNutrient();

            // Select a random food from the list
            var random = new Random();
            var index = random.Next(foodList.Count);
            return foodList[index];
        }

        private List<Food> GetFoodsForNutrient(int id = 1003)
        {
            var foods = new List<Food>();
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Models", "USDA", "foods.json");
            string myJsonResponse = File.ReadAllText(jsonFilePath);
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
            var top100Foods = myDeserializedClass.FoundationFoods
            .Where(f => f.FoodNutrients.Any(n => n.Nutrient.Id == id))
            .OrderByDescending(f => f.FoodNutrients.First(n => n.Nutrient.Id == id).Amount)
            .Take(100);
            return (List<Food>)top100Foods;
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

        public void AddFood(Food food)
        {
            _unitOfWork.Repository.Add(food);
        }

        public double CalculateMSCORE()
        {
            // Calculate MSCORE based on the current list of foods in the meal plan
            throw new NotImplementedException();
        }

        public void RemoveFood(Food food)
        {
            _unitOfWork.Repository.Remove(food);
        }

        public void AddFoodsToMealPlan(List<Nutrient> nutrients)
        {
            foreach (var nutrient in nutrients)
            {
                // Select a random food from the list of 100 foods that contain the highest amount of the nutrient
                var food = SelectFood(nutrient);

                // Calculate the new MSCORE after adding the food to the meal plan
                var newMSCORE = CalculateMSCORE();

                // Check if any nutrient exceeds its upper bound after adding the food
                var nutrientExceedsUB = CheckForExceededNutrient(newMSCORE);

                // If a nutrient exceeds its upper bound, remove the food and try again
                if (nutrientExceedsUB)
                {
                    RemoveFood(food);
                }
                else
                {
                    // Otherwise, add the food to the meal plan
                    AddFood(food);
                }


            }
        }

        public void DefineNutrients()
        {
            // Define nutrients list to consider when adding foods to the meal plan
            var nutrients = new List<Nutrient>
            {
                new Nutrient { Name = "Vitamin C" },
                new Nutrient { Name = "Vitamin B1" },
                new Nutrient { Name = "Vitamin B2"}
            };

        }

        public void CreateMealPlan()
        {
            // Initialize the meal plan with an empty foods list
            var mealPlan = new MealPlan() { Foods = new List<Food>() };

        }
    }
}

