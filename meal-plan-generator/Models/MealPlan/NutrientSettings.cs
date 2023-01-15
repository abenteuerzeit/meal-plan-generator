using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace meal_plan_generator.Models.MealPlan
{
    public class NutrientSettings : EntityBase
    {

        [ForeignKey(nameof(Nutrient)), Required]
        public int NutrientId { get; set; }

        [Required]
        [DisplayName("importance")]
        public int Weight { get; set; } = 1;
        [Required]
        [DisplayName("default")]
        public int Intercept { get; set; } = 1;


        [Range(0, int.MaxValue, ErrorMessage = "Only positive values allowed.")]
        [DisplayName("minimum")]
        public double LowerBound { get; set; } = 100;

        [Range(0, int.MaxValue, ErrorMessage = "Only positive values allowed.")]
        [DisplayName("ideal")]
        public double IdealAmount { get; set; } = 250;

        [Range(0, int.MaxValue, ErrorMessage = "Only positive values allowed.")]
        [DisplayName("maximum")]
        public double UpperBound { get; set; } = 500;

        public NutrientSettings() { }

    }
}
