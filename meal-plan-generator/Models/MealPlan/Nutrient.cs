using meal_plan_generator.Models.USDA;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace meal_plan_generator.Models.MealPlan
{
    public class Nutrient : EntityBase
    {
        public string Name { get; set; } = "Name not set";
        public string Unit { get; set; } = "Undefined";
        public float Quantity { get; set; }
        public int NutrientSettingsId { get; set; }
        public NutrientSettings Settings { get; set; }
        public ComponentId ComponentId { get; internal set; }

        public Nutrient()
        {
            Settings = new NutrientSettings();
        }
        public Nutrient(ComponentId id)
        {
            Settings = new NutrientSettings();
        }
        private static decimal GetNutrientDefault(ComponentId id)
        {
            // TODO: Set default minimum values
            return 1;
        }


        //public decimal GetNutrientScore()
        //{
        //    // Use the appropriate function based on the current quantity of the nutrient
        //    if (IdealAmount < CurrentNutrientQuantity && CurrentNutrientQuantity <= MaxAmount)
        //    {
        //        return GetNutrientLessThanMaxScore();
        //    }
        //    else if (MinAmount < CurrentNutrientQuantity && CurrentNutrientQuantity <= IdealAmount)
        //    {
        //        return GetNutrientGreaterThanMinScore();
        //    }
        //    else if (0 <= CurrentNutrientQuantity && CurrentNutrientQuantity <= MinAmount)
        //    {
        //        return GetNutrientLessThanMinScore();
        //    }
        //    else
        //    {
        //        // Return 0 if the current quantity is outside the valid range (less than 0)
        //        throw new ArgumentOutOfRangeException(nameof(CurrentNutrientQuantity));
        //        //return 0;
        //    }
        //}

        //private decimal GetNutrientLessThanMinScore()
        //{
        //    // Return a value based on the priority and current quantity if the current quantity is greater than or equal to 0
        //    return (PrioritySettings.LessThanMin["Weight"] * (CurrentNutrientQuantity / MinAmount)) + PrioritySettings.LessThanMin["Intercept"];
        //}

        //private decimal GetNutrientGreaterThanMinScore()
        //{
        //    // Return a value based on the priority and current quantity if the current quantity is greater than or equal to the ideal amount and greater than or equal to the lower bound
        //    return (PrioritySettings.MoreThanMin["Weight"] * (CurrentNutrientQuantity / IdealAmount)) + PrioritySettings.MoreThanMin["Intercept"];
        //}

        //private decimal GetNutrientLessThanMaxScore()
        //{
        //    // Return a value based on the priority and current quantity if the current quantity is greater than the ideal amount and less than or equal to the upper bound
        //    return -(PrioritySettings.LessThanMax["Weight"] * (CurrentNutrientQuantity / MaxAmount)) + PrioritySettings.LessThanMax["Intercept"];
        //}

        public bool IsMet()
        {
            return Quantity >= Settings.LowerBound && Quantity <= Settings.UpperBound;
        }
    }
}
