using meal_plan_generator.Models.USDA;

namespace meal_plan_generator.Models.MealPlan
{
    public class MealPlan
    {
        public List<FoundationFood> FoundationFoods;
        private List<Nutrient> nutrients;

        public MealPlan()
        {
            FoundationFoods = new List<FoundationFood>();
            nutrients = new List<Nutrient>();
        }

        public void AddFood(FoundationFood food)
        {
            FoundationFoods.Add(food);
        }

        public void removeFood(FoundationFood food)
        {
            FoundationFoods.Remove(food);
        }

        public void AddNutrient(Nutrient nutrient)
        {
            nutrients.Add(nutrient);
        }

        public decimal CalculateScore()
        {
            decimal totalScore = 0;
            foreach (Nutrient nutrient in nutrients)
            {
                totalScore += nutrient.GetNutrientScore();
            }
            return totalScore / nutrients.Count;
        }

        public bool IsAcceptable()
        {
            foreach (Nutrient nutrient in nutrients)
            {
                if (!nutrient.IsMet())
                {
                    return false;
                }
            }
            return true;
        }

        public Food? SelectFood(List<Food> topFoods)
        {
            // Find the next unmet nutrient
            Nutrient? unmetNutrient = null;
            foreach (Nutrient nutrient in nutrients)
            {
                if (!nutrient.IsMet())
                {
                    unmetNutrient = nutrient;
                    break;
                }
            }

            // If all nutrients are met, return null
            if (unmetNutrient == null)
            {
                return null;
            }

            // Select a random food from the top foods list
            Random rnd = new Random();
            int index = rnd.Next(topFoods.Count);
            Food selectedFood = topFoods[index];

            // Check if the selected food meets the criteria for the unmet nutrient
            if (selectedFood.GetNutrientAmount(unmetNutrient.Name) >= unmetNutrient.IdealAmount)
            {
                return selectedFood;
            }
            else
            {
                return null;
            }
        }
    }
}
