using meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Repository;
using meal_plan_generator.UnitofWork;

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
            throw new NotImplementedException();
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
    }
}

