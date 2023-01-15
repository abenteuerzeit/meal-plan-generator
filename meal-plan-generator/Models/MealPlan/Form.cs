using meal_plan_generator.Models.MealPlan;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Linq;

namespace meal_plan_generator.Models.MealPlan
{
    public class Form : EntityBase
    {
        [Required]
        [DisplayName("Nutrient Data")]
        public virtual IList<Nutrient> Nutrients { get; set; } = SetDefaultNutrientData();
        public Form()
        {
        }

        public Form(IList<Nutrient> nutrients)
        {
            Nutrients = nutrients;
        }

        private static List<Nutrient> SetDefaultNutrientData()
        {
            return new List<Nutrient>
            {
                new Nutrient("Calcium", "mg") { Settings = new NutrientSettings { LowerBound = 1000, IdealAmount = 1150, UpperBound = 1300 } },
                new Nutrient("Phosphorus", "mg") { Settings = new NutrientSettings { LowerBound = 1000, IdealAmount = 1250, UpperBound = 1300 } },
                new Nutrient("Magnesium", "mg") { Settings = new NutrientSettings { LowerBound = 400, IdealAmount = 410, UpperBound = 420 } },
                new Nutrient("Potasium", "mg") { Settings = new NutrientSettings { LowerBound = 3500, IdealAmount=4000, UpperBound = 4700 } },
                new Nutrient("Sodium", "mg") { Settings = new NutrientSettings { LowerBound = 0, IdealAmount = 0, UpperBound = 2400 } },
                new Nutrient("Iron", "mg") { Settings = new NutrientSettings { LowerBound = 18, IdealAmount = 20, UpperBound = 25 } },
                new Nutrient("Manganese", "mg") { Settings = new NutrientSettings { LowerBound = 2, IdealAmount = 3, UpperBound = 4 } },
                new Nutrient("Copper", "mg") { Settings = new NutrientSettings { LowerBound = 0, IdealAmount = 1, UpperBound = 2 } },
                new Nutrient("Zinc", "mg") { Settings = new NutrientSettings { LowerBound = 0, IdealAmount = 11, UpperBound = 15 } },
                new Nutrient("Selenium", "mcg") { Settings = new NutrientSettings {LowerBound = 0, IdealAmount = 55, UpperBound = 70 } },
                new Nutrient("Vitamin A", "mcg") { Settings = new NutrientSettings { LowerBound = 5000, IdealAmount = 5000, UpperBound=5500} },
                new Nutrient("Vitamin C", "mg") { Settings = new NutrientSettings { LowerBound = 60, IdealAmount = 90, UpperBound=100} },
                new Nutrient("Vitamin E", "mg") { Settings = new NutrientSettings { LowerBound = 15, IdealAmount = 15, UpperBound=20 } },
                new Nutrient("Vitamin K", "mcg") { Settings = new NutrientSettings { LowerBound = 80, IdealAmount = 120, UpperBound=140 } },
                new Nutrient("Thiamin", "mg") { Settings = new NutrientSettings { LowerBound = 1, IdealAmount = 2, UpperBound = 2 } },
                new Nutrient("Roboflavin", "mg") { Settings = new NutrientSettings { LowerBound = 1, IdealAmount = 2, UpperBound = 3 } },
                new Nutrient("Niacin", "mg") { Settings = new NutrientSettings { LowerBound = 0, IdealAmount = 16, UpperBound = 20 } },
                new Nutrient("Pantothenic Acid", "mg") { Settings = new NutrientSettings { LowerBound = 0, IdealAmount = 5, UpperBound = 10 } },
                new Nutrient("Folate", "mcg") { Settings = new NutrientSettings { LowerBound = 400, IdealAmount = 400, UpperBound = 1000 } }
            };
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("Nutrient Data:");
            foreach (Nutrient nutrient in Nutrients)
            {
                sb.AppendLine($"{nutrient.Name}: {nutrient.Settings.IdealAmount} {nutrient.Unit} (Lower Bound: {nutrient.Settings.LowerBound}, Upper Bound: {nutrient.Settings.UpperBound})");
            }
            return sb.ToString();
        }

    }
}

