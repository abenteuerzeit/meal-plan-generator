using meal_plan_generator.Models.USDA;
using System.ComponentModel.DataAnnotations;

namespace meal_plan_generator.Models.MealPlan
{
    public class MealPlan : EntityBase
    {
        public List<Food> Foods { get; set; }
        public MealPlan()
        {
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

        public double CalculateScore()
        {
            //var nutDict = Foods.SelectMany(f => f.Nutrients)
            //                    .GroupBy(n => n.Name)
            //                    .ToDictionary(g => g.Key, g => g.Sum(x => x.Quantity));


            double totalScore = 0;
            do
            {
                var nutDict = new Dictionary<Nutrient, double>();
            foreach (var food in Foods)
            {
                foreach (Nutrient nutrient in food.Nutrients)
                {
                    if (nutDict.ContainsKey(nutrient))
                    {
                        nutDict[nutrient] += nutrient.Quantity;
                    }
                    else
                    {
                        nutDict.Add(nutrient, nutrient.Quantity);
                    }
                }
            }

                foreach ((Nutrient nutrient, double quantity) in nutDict)
                {
                    totalScore += nutrient.GetNutrientScore(nutrient.Settings);
                }
            } while (totalScore == 0);


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
