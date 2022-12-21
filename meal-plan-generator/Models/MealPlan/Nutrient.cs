using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace meal_plan_generator.Models.MealPlan
{
    public class Nutrient
    {
        public string Name { get; set; }
        public decimal MinAmount { get; set; } = default;
        public decimal IdealAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal CurrentNutrientQuantity { get; set; }
        public NutrientSettings PrioritySettings { get; set; }

        public Nutrient(string name, decimal minAmount, decimal idealAmount, decimal maxAmount, decimal currentAmount, NutrientSettings priority)
        {
            Name = name;
            MinAmount = minAmount;
            IdealAmount = idealAmount;
            MaxAmount = maxAmount;
            CurrentNutrientQuantity = currentAmount;
            PrioritySettings = priority;
        }

        public double GetNutrientScore()
        {
            // Use the appropriate function based on the current quantity of the nutrient
            if ( IdealAmount < CurrentNutrientQuantity && CurrentNutrientQuantity <= MaxAmount)
            {
                return GetNutrientLessThanMaxScore();
            }
            else if (MinAmount < CurrentNutrientQuantity && CurrentNutrientQuantity <= IdealAmount )
            {
                return GetNutrientGreaterThanMinScore();
            }
            else if (0 <= CurrentNutrientQuantity && CurrentNutrientQuantity <= MinAmount)
            {
                return GetNutrientLessThanMinScore();
            }
            else
            {
                // Return 0 if the current quantity is outside the valid range (less than 0)
                throw new ArgumentOutOfRangeException(nameof(CurrentNutrientQuantity));
                return 0;
            }
        }

        private double GetNutrientLessThanMinScore()
        {
            // Return a value based on the priority and current quantity if the current quantity is greater than or equal to 0
            return (PrioritySettings.LessThanMin["Weight"] * (CurrentNutrientQuantity / MinAmount)) + PrioritySettings.LessThanMin["Intercept"];
        }

        private double GetNutrientGreaterThanMinScore()
        {
            // Return a value based on the priority and current quantity if the current quantity is greater than or equal to the ideal amount and greater than or equal to the lower bound
            return (PrioritySettings.MoreThanMin["Weight"] * (CurrentNutrientQuantity / IdealAmount)) + PrioritySettings.MoreThanMin["Intercept"];
        }

        private double GetNutrientLessThanMaxScore()
        {
            // Return a value based on the priority and current quantity if the current quantity is greater than the ideal amount and less than or equal to the upper bound
            return -(PrioritySettings.LessThanMax["Weight"] * (CurrentNutrientQuantity / MaxAmount)) + PrioritySettings.LessThanMax["Intercept"];
        }

        public bool IsMet()
        {
            return CurrentNutrientQuantity >= MinAmount && CurrentNutrientQuantity <= MaxAmount;
        }
    }
}
