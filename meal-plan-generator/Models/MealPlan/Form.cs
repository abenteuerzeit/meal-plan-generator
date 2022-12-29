using meal_plan_generator.Models.MealPlan;
using System.ComponentModel.DataAnnotations;

namespace meal_plan_generator.Models.MealPlan
{
    public class NutrientData
    {
        [Key, Required]
        public int Id { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public float LowerBound { get; set; }
        public float IdealAmount { get; set; }
        public float UpperBound { get; set; }
        public int FormId { get; set; }
    }

    public class Form
    {
        [Key, Required]
        public int Id { get; internal set; }
        public List<NutrientData> NutrientData { get; set; }

        public Form()
        {
            NutrientData = new List<NutrientData>()
            {
                new NutrientData { Name = "Calcium", Unit = "mg" },
                new NutrientData { Name = "Phosphorus", Unit = "mg" },
                new NutrientData { Name = "Magnesium", Unit = "mg" },
                new NutrientData { Name = "Potassium", Unit = "mg" },
                new NutrientData { Name = "Sodium", Unit = "mg" },
                new NutrientData { Name = "Iron", Unit = "mg" },
                new NutrientData { Name = "Manganese", Unit = "mg" },
                new NutrientData { Name = "Copper", Unit = "mg" },
                new NutrientData { Name = "Zinc", Unit = "mg" },
                new NutrientData { Name = "Selenium", Unit = "mcg" },
                new NutrientData { Name = "Vitamin A", Unit = "IU" },
                new NutrientData { Name = "Vitamin C", Unit = "mg" },
                new NutrientData { Name = "Vitamin E", Unit = "mg" },
                new NutrientData { Name = "Vitamin K", Unit = "mcg" },
                new NutrientData { Name = "Thiamin", Unit = "mg" },
                new NutrientData { Name = "Roboflavin", Unit = "mg" },
                new NutrientData { Name = "Niacin", Unit = "mg" },
                new NutrientData { Name = "Pantothenic Acid", Unit = "mg" },
                new NutrientData { Name = "Folate", Unit = "mcg" }
            };
        }
    }
}

