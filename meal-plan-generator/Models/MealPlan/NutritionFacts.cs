namespace meal_plan_generator.Models.MealPlan
{
    public class NutritionFacts
    {
        public float ServingSize { get; set; }
        public float Calories { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public float Protein { get; set; }
        public float Sodium { get; set; }
        public float Cholesterol { get; set; }
        public float Sugar { get; set; }

        public Dictionary<string, float> GetMacronutrients()
        {
            return new Dictionary<string, float>
            {
                {"fat", Fat },
                {"carbohydrates", Carbohydrates },
                {"protein", Protein }
            };
        }

        public Dictionary<string, float> GetMicronutrients()
        {
            return new Dictionary<string, float>
            {
                {"sodium", Sodium },
                {"cholesterol", Cholesterol },
                {"sugar", Sugar }
            };
        }
    }
}

