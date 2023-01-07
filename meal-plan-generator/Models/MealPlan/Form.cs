using meal_plan_generator.Models.MealPlan;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace meal_plan_generator.Models.MealPlan
{
    public class NutrientData
    {
        [Key, Required]
        public int Id { get; set; }

        //[ForeignKey(nameof(Form))]
        public int FormId { get; set; }

        public string Name { get; set; } = "";
        public string Unit { get; set; } = "";

        [Required]
        public int Weight { get; set; } = 1;
        [Required]
        public int Intercept { get; set; } = 1;


        [Range(0, int.MaxValue, ErrorMessage = "Only positive values allowed.")]
        public float LowerBound { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Only positive values allowed.")]
        public float IdealAmount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Only positive values allowed.")]
        public float UpperBound { get; set; }

    }

    public class Form : EntityBase
    {
        [Required]
        public ICollection<NutrientData> NutrientData { get; set; }

        public Form()
        {
            NutrientData = SetDefaultNutrientData();
        }

        public Form(HashSet<NutrientData> nutrients)
        {
            NutrientData = nutrients;
        }

        private static ICollection<NutrientData> SetDefaultNutrientData()
        {
            return new HashSet<NutrientData>()
            {
                new NutrientData { Name = "Calcium", Unit = "mg", LowerBound=1000, IdealAmount=1300 },
                new NutrientData { Name = "Phosphorus", Unit = "mg", LowerBound=1000, IdealAmount=1250},
                new NutrientData { Name = "Magnesium", Unit = "mg", LowerBound=400, IdealAmount=420 },
                new NutrientData { Name = "Potassium", Unit = "mg", LowerBound=3500, IdealAmount=4700 },
                new NutrientData { Name = "Sodium", Unit = "mg", IdealAmount = 2300, UpperBound=2400 },
                new NutrientData { Name = "Iron", Unit = "mg", LowerBound=18 },
                new NutrientData { Name = "Manganese", Unit = "mg", LowerBound=2, IdealAmount=2.3F },
                new NutrientData { Name = "Copper", Unit = "mg", IdealAmount=0.9F, UpperBound=2 },
                new NutrientData { Name = "Zinc", Unit = "mg", IdealAmount=11, UpperBound=15 },
                new NutrientData { Name = "Selenium", Unit = "mcg", IdealAmount=55, UpperBound=70 },
                new NutrientData { Name = "Vitamin A", Unit = "mcg", LowerBound=5000, IdealAmount=5000 }, // TODO: Unit of measure change! The FDA now reccomends mcg, not IU
                new NutrientData { Name = "Vitamin C", Unit = "mg",LowerBound=60, IdealAmount=90 },
                new NutrientData { Name = "Vitamin E", Unit = "mg", LowerBound=15, IdealAmount=15 }, // TODO: Unit of measure change! The Daily Value decrease for vitamin E applies for foods/supplements containing the natural form of vitamin E, but not for the synthetic form. For foods/supplements containing only the synthetic form of vitamin E, the DV increased.
                new NutrientData { Name = "Vitamin K", Unit = "mcg", LowerBound=80, IdealAmount=120 },
                new NutrientData { Name = "Thiamin", Unit = "mg", LowerBound=1.2F, IdealAmount = 1.5F },
                new NutrientData { Name = "Roboflavin", Unit = "mg", LowerBound=1.3F, IdealAmount=1.7F },
                new NutrientData { Name = "Niacin", Unit = "mg", IdealAmount=16, UpperBound=20 },
                new NutrientData { Name = "Pantothenic Acid", Unit = "mg", IdealAmount=5, UpperBound=10 },
                new NutrientData { Name = "Folate", Unit = "mcg", LowerBound=400 }
            };
        }

        public ICollection<NutrientData> GetNutrientSettings()
        {
            return new List<NutrientData>();
        }

        public void SetNutrientData(ICollection<NutrientData> nutrientData)
        {
            NutrientData = nutrientData;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("Nutrient Data:");
            foreach (NutrientData nutrient in NutrientData)
            {
                sb.AppendLine($"{nutrient.Name}: {nutrient.IdealAmount} {nutrient.Unit} (Lower Bound: {nutrient.LowerBound}, Upper Bound: {nutrient.UpperBound})");
            }
            return sb.ToString();
        }
    }
}

