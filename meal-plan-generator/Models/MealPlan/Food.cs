using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace meal_plan_generator.Models.MealPlan
{
    public class Food : EntityBase
    {
        public int FoodId { get; set; }

        public int NutrientId { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Nutrient> Nutrients { get; set; }
        public double Servings { get; set; }
        public double ServingSize { get; set; }
        public int CaloriesPerServing { get; set; }

        public Food()
        {

        }

        public Food(string name, List<Nutrient> nutrients)
        {
            Name = name;
            Nutrients = nutrients;
        }

    }
}
