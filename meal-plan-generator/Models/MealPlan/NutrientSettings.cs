using System.ComponentModel.DataAnnotations;

namespace meal_plan_generator.Models.MealPlan
{
    public class NutrientSettings
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
}
