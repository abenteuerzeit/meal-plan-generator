using meal_plan_generator.Models.USDA;
using System.ComponentModel.DataAnnotations;

namespace meal_plan_generator.Models.MealPlan
{
    public class MealPlan : EntityBase
    {
        public List<FoundationFood> FoundationFoods { get; set; }
        public List<Food> Foods { get; set; }

        public MealPlan()
        {
            FoundationFoods = new List<FoundationFood>();
            Foods = new List<Food>();
        }

        public void AddFood(Food food)
        {
            Foods.Add(food);
        }

        public void removeFood(Food food)
        {
            Foods.Remove(food);
        }

        public void AddNutrient(Food nutrient)
        {
            Foods.Add(nutrient);
        }

        public double CalculateScore(List<Nutrient> nutrients)
        {
            double totalScore = 0;
            foreach (var nutrient in nutrients)
            {
                totalScore += nutrient.GetNutrientScore(nutrient.Settings);
            }
            return totalScore / Foods.Count;
        }

        public bool IsAcceptable()
        {
            foreach (var nutrient in Foods)
            {
                //if (!nutrient.IsMet())
                //{
                //    return false;
                //}
            }
            return true;
        }

        //public Food? SelectFood(List<Food> topFoods)
        //{
        //    // Find the next unmet nutrient
        //    Food? unmetNutrient = null;
        //    foreach (Food food in Foods)
        //    {
        //        var nutrient = food.Nutrients;
        //        if (!nutrient.IsMet())
        //        {
        //            unmetNutrient = nutrient;
        //            break;
        //        }
        //    }

        //    // If all nutrients are met, return null
        //    if (unmetNutrient == null)
        //    {
        //        return null;
        //    }

        //    // Select a random food from the top foods list
        //    Random rnd = new Random();
        //    int index = rnd.Next(topFoods.Count);
        //    Food selectedFood = topFoods[index];

        //    // Check if the selected food meets the criteria for the unmet nutrient
        //    if (selectedFood.GetNutrientAmount(unmetNutrient.Name) >= unmetNutrient.Settings.IdealAmount)
        //    {
        //        return selectedFood;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
