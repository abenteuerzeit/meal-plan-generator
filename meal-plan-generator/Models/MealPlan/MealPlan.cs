using meal_plan_generator.Models.USDA;
using System.ComponentModel.DataAnnotations;

namespace meal_plan_generator.Models.MealPlan
{
    public class MealPlan : EntityBase
    {
        //[Key]
        //public int Id { get; set; }
        public List<FoundationFood> FoundationFoods;
        public List<Nutrient> Nutrients;

        public MealPlan()
        {
            FoundationFoods = new List<FoundationFood>();
            Nutrients = new List<Nutrient>();
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
            Nutrients.Add(nutrient);
        }

        public float CalculateScore()
        {
            float totalScore = 0;
            //foreach (Nutrient nutrient in Nutrients)
            //{
            //    totalScore += nutrient.GetNutrientScore();
            //}
            return totalScore / Nutrients.Count;
        }

        public bool IsAcceptable()
        {
            foreach (Nutrient nutrient in Nutrients)
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
            foreach (Nutrient nutrient in Nutrients)
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
            if (selectedFood.GetNutrientAmount(unmetNutrient.Name) >= unmetNutrient.Settings.IdealAmount)
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
