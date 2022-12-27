namespace meal_plan_generator.Models.MealPlan
{
    public class NutrientSettings
    {
        public Dictionary<string, int> LessThanMax { get; set; } = UseDefaults();
        public Dictionary<string, int> MoreThanMin { get; set; } = UseDefaults();
        public Dictionary<string, int> LessThanMin { get; set; } = UseDefaults();


        NutrientSettings(Dictionary<string, int> lessThanMax, Dictionary<string, int> moreThanMin, Dictionary<string, int> lessThanMin)
        {

            LessThanMax = lessThanMax;
            MoreThanMin = moreThanMin;
            LessThanMin = lessThanMin;
        }

        private static Dictionary<string, int> UseDefaults()
        {
            return new Dictionary<string, int>()
                {
                    { "Weight", 1 },
                    { "Intercept", 1 }
                };
        }
    }
}
