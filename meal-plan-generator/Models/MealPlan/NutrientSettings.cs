namespace meal_plan_generator.Models.MealPlan
{
    public class NutrientSettings
    {
        public Dictionary<string, int> LessThanMax { get; set; } = useDefaults();
        public Dictionary<string, int> MoreThanMin { get; set; } = useDefaults();
        public Dictionary<string, int> LessThanMin { get; set; } = useDefaults();


        NutrientSettings(Dictionary<string, int> lessThanMax, Dictionary<string, int> moreThanMin, Dictionary<string, int> lessThanMin)
        {

            LessThanMax = lessThanMax;
            MoreThanMin = moreThanMin;
            LessThanMin = lessThanMin;
        }

        private static Dictionary<string, int> useDefaults()
        {
            return new Dictionary<string, int>()
                {
                    { "Weight", 1 },
                    { "Intercept", 1 }
                };
        }
    }
}
