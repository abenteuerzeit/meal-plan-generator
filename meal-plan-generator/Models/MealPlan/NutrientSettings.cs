using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace meal_plan_generator.Models.MealPlan
{
    public class NutrientSettings : EntityBase
    {

        [ForeignKey(nameof(Nutrient)), Required]
        public int NutrientId { get; set; }

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

        public NutrientSettings() { }

    }
}
