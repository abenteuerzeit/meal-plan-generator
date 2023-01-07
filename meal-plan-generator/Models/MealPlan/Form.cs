using meal_plan_generator.Models.MealPlan;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace meal_plan_generator.Models.MealPlan
{
    public class Form : EntityBase
    {
        [Required]
        public ICollection<Nutrient> NutrientData { get; set; }

        public Form()
        {
            NutrientData = SetDefaultNutrientData();
        }

        public Form(HashSet<Nutrient> nutrients)
        {
            NutrientData = nutrients;
        }

        private static HashSet<Nutrient> SetDefaultNutrientData()
        {
            return new HashSet<Nutrient>
            {
                new Nutrient { Name = "Calcium", Unit = "mg", Settings = new NutrientSettings { LowerBound = 1000, UpperBound = 1300 } },
                new Nutrient { Name = "Phosphorus", Unit = "mg", Settings = new NutrientSettings { LowerBound = 1000, IdealAmount = 1250 } },
                new Nutrient { Name = "Magnesium", Unit = "mg", Settings = new NutrientSettings { LowerBound = 400, IdealAmount = 420 } },
                new Nutrient { Name = "Potassium", Unit = "mg", Settings = new NutrientSettings { LowerBound = 3500, IdealAmount = 4700 } },
                new Nutrient { Name = "Sodium", Unit = "mg", Settings = new NutrientSettings { IdealAmount = 2300, UpperBound = 2400 } },
                new Nutrient { Name = "Iron", Unit = "mg", Settings = new NutrientSettings { LowerBound = 18 } },
                new Nutrient { Name = "Manganese", Unit = "mg", Settings = new NutrientSettings { LowerBound = 2, IdealAmount = 2.3F } },
                new Nutrient { Name = "Copper", Unit = "mg", Settings = new NutrientSettings { IdealAmount = 0.9F, UpperBound = 2 } },
                new Nutrient { Name = "Zinc", Unit = "mg", Settings = new NutrientSettings { IdealAmount = 11, UpperBound = 15 } },
                new Nutrient { Name = "Selenium", Unit = "mcg", Settings = new NutrientSettings { IdealAmount = 55, UpperBound = 70 } },
                new Nutrient { Name = "Vitamin A", Unit = "mcg", Settings = new NutrientSettings { LowerBound = 5000, IdealAmount = 5000 } },
                new Nutrient { Name = "Vitamin C", Unit = "mg", Settings = new NutrientSettings { LowerBound = 60, IdealAmount = 90 } },
                new Nutrient { Name = "Vitamin E", Unit = "mg", Settings = new NutrientSettings { LowerBound = 15, IdealAmount = 15 } },
                new Nutrient { Name = "Vitamin K", Unit = "mcg", Settings = new NutrientSettings { LowerBound = 80, IdealAmount = 120 } },
                new Nutrient { Name = "Thiamin", Unit = "mg", Settings = new NutrientSettings { LowerBound = 1.2F, IdealAmount = 1.5F } },
                new Nutrient { Name = "Roboflavin", Unit = "mg", Settings = new NutrientSettings { LowerBound = 1.3F, IdealAmount = 1.7F } },
                new Nutrient { Name = "Niacin", Unit = "mg", Settings = new NutrientSettings { IdealAmount = 16, UpperBound = 20 } },
                new Nutrient { Name = "Pantothenic Acid", Unit = "mg", Settings = new NutrientSettings { IdealAmount = 5, UpperBound = 10 } },
                new Nutrient { Name = "Folate", Unit = "mcg", Settings = new NutrientSettings { LowerBound = 400 } }
            };
        }

        public ICollection<Nutrient> GetNutrientSettings()
        {
            return new List<Nutrient>();
        }

        public void SetNutrientData(ICollection<Nutrient> nutrientData)
        {
            NutrientData = nutrientData;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("Nutrient Data:");
            foreach (Nutrient nutrient in NutrientData)
            {
                sb.AppendLine($"{nutrient.Name}: {nutrient.Settings.IdealAmount} {nutrient.Unit} (Lower Bound: {nutrient.Settings.LowerBound}, Upper Bound: {nutrient.Settings.UpperBound})");
            }
            return sb.ToString();
        }

    }
}

