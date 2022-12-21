namespace meal_plan_generator.Models.MealPlan
{
    public class Nutrient
    {
        public string Name { get; set; }
        public float MinAmount { get; set; }
        public float IdealAmount { get; set; }
        public float MaxAmount { get; set; }
        public float CurrentAmount { get; set; }
        public int Priority { get; set; }

        public Nutrient(string name, float minAmount, float idealAmount, float maxAmount, float currentAmount, int priority)
        {
            Name = name;
            MinAmount = minAmount;
            IdealAmount = idealAmount;
            MaxAmount = maxAmount;
            CurrentAmount = currentAmount;
            Priority = priority;
        }

        public float CalculateScore()
        {
            // Calculate the nutrient amount in relation to the min, ideal, and max amounts
            float nutrientAmount = CurrentAmount / IdealAmount;

            // Use the appropriate function based on the nutrient amount
            if (MaxAmount >= CurrentAmount > IdealAmount)
            {
                return (-1 * Priority * nutrientAmount) + 1;
            }
            else if (IdealAmount >= CurrentAmount > MinAmount)
            {
                return Priority * nutrientAmount + 1;
            }
            else if (MinAmount >= CurrentAmount >= 0)
            {
                return Priority * nutrientAmount + 1;
            }
            else
            {
                // Return 0 if the nutrient amount is outside the valid range
                return 0;
            }
        }

        public bool IsMet()
        {
            return CurrentAmount >= MinAmount && CurrentAmount <= MaxAmount;
        }
    }
}
