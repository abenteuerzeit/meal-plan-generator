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
        public ICollection<NutrientSettings> NutrientData { get; set; }

        public Form()
        {
            NutrientData = SetDefaultNutrientData();
        }

        public Form(HashSet<NutrientSettings> nutrients)
        {
            NutrientData = nutrients;
        }

        private static ICollection<NutrientSettings> SetDefaultNutrientData()
        {
            return new HashSet<NutrientSettings>()
            {
                new NutrientSettings { Name = "Calcium", Unit = "mg", LowerBound=1000, IdealAmount=1300 },
                new NutrientSettings { Name = "Phosphorus", Unit = "mg", LowerBound=1000, IdealAmount=1250},
                new NutrientSettings { Name = "Magnesium", Unit = "mg", LowerBound=400, IdealAmount=420 },
                new NutrientSettings { Name = "Potassium", Unit = "mg", LowerBound=3500, IdealAmount=4700 },
                new NutrientSettings { Name = "Sodium", Unit = "mg", IdealAmount = 2300, UpperBound=2400 },
                new NutrientSettings { Name = "Iron", Unit = "mg", LowerBound=18 },
                new NutrientSettings { Name = "Manganese", Unit = "mg", LowerBound=2, IdealAmount=2.3F },
                new NutrientSettings { Name = "Copper", Unit = "mg", IdealAmount=0.9F, UpperBound=2 },
                new NutrientSettings { Name = "Zinc", Unit = "mg", IdealAmount=11, UpperBound=15 },
                new NutrientSettings { Name = "Selenium", Unit = "mcg", IdealAmount=55, UpperBound=70 },
                new NutrientSettings { Name = "Vitamin A", Unit = "mcg", LowerBound=5000, IdealAmount=5000 }, // TODO: Unit of measure change! The FDA now reccomends mcg, not IU
                new NutrientSettings { Name = "Vitamin C", Unit = "mg",LowerBound=60, IdealAmount=90 },
                new NutrientSettings { Name = "Vitamin E", Unit = "mg", LowerBound=15, IdealAmount=15 }, // TODO: Unit of measure change! The Daily Value decrease for vitamin E applies for foods/supplements containing the natural form of vitamin E, but not for the synthetic form. For foods/supplements containing only the synthetic form of vitamin E, the DV increased.
                new NutrientSettings { Name = "Vitamin K", Unit = "mcg", LowerBound=80, IdealAmount=120 },
                new NutrientSettings { Name = "Thiamin", Unit = "mg", LowerBound=1.2F, IdealAmount = 1.5F },
                new NutrientSettings { Name = "Roboflavin", Unit = "mg", LowerBound=1.3F, IdealAmount=1.7F },
                new NutrientSettings { Name = "Niacin", Unit = "mg", IdealAmount=16, UpperBound=20 },
                new NutrientSettings { Name = "Pantothenic Acid", Unit = "mg", IdealAmount=5, UpperBound=10 },
                new NutrientSettings { Name = "Folate", Unit = "mcg", LowerBound=400 }
            };
        }

        public ICollection<NutrientSettings> GetNutrientSettings()
        {
            return new List<NutrientSettings>();
        }

        public void SetNutrientData(ICollection<NutrientSettings> nutrientData)
        {
            NutrientData = nutrientData;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("Nutrient Data:");
            foreach (NutrientSettings nutrient in NutrientData)
            {
                sb.AppendLine($"{nutrient.Name}: {nutrient.IdealAmount} {nutrient.Unit} (Lower Bound: {nutrient.LowerBound}, Upper Bound: {nutrient.UpperBound})");
            }
            return sb.ToString();
        }
    }
}

