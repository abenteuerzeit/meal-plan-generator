namespace meal_plan_generator.Models.MealPlan
{
    public class MealPlan
    {
        private List<Food> foods;
        private List<Nutrient> nutrients;

        // TODO: Generate a FDA Nutrition Facts label for the Meal Plan
        //private string servingSize = "1 1/2 cup (208g)";
        //private int servingsPerContainer = 4;
        //private int caloriesPerServing = 240;
        //private double totalFatPerServing = 4;
        //private double saturatedFatPerServing = 1.5;
        //private int cholesterolPerServing = 5;
        //private int sodiumPerServing = 430;
        //private double totalCarbohydratePerServing = 46;
        //private double dietaryFiberPerServing = 7;
        //private double totalSugarsPerServing = 4;
        //private double addedSugarsPerServing = 2;
        //private int proteinPerServing = 11;
        //private double vitaminDPerServing = 2;
        //private double calciumPerServing = 260;
        //private double ironPerServing = 6;
        //private double potassiumPerServing = 240;

        public MealPlan()
        {
            foods = new List<Food>();
            nutrients = new List<Nutrient>();
        }

        public void AddFood(Food food)
        {
            foods.Add(food);
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
