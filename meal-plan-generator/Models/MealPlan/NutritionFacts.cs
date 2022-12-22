namespace meal_plan_generator.Models.MealPlan
{
    public class NutritionFacts
    {
        public double ServingSize { get; set; }
        public double Calories { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Protein { get; set; }
        public double Cholesterol { get; set; }
        public double Sugar { get; set; }
        public double Calcium { get; set; }
        public double Phosphorus { get; set; }
        public double Magnesium { get; set; }
        public double Potassium { get; set; }
        public double Sodium { get; set; }
        public double Iron { get; set; }
        public double Manganese { get; set; }
        public double Copper { get; set; }
        public double Zinc { get; set; }
        public double Selenium { get; set; }
        public double VitaminA { get; set; }
        public double VitaminC { get; set; }
        public double VitaminE { get; set; }
        public double VitaminK { get; set; }
        public double Thiamin { get; set; }
        public double Roboflavin { get; set; }
        public double Niacin { get; set; }
        public double PantothenicAcid { get; set; }
        public double Folate { get; set; }


        public Dictionary<string, double> GetMacronutrients()
        {
            return new Dictionary<string, double>
            {
                {"fat", Fat },
                {"carbohydrates", Carbohydrates },
                {"protein", Protein }
            };
        }

        public Dictionary<string, double> GetMicronutrients()
        {
            return new Dictionary<string, double>
            {
                {"sodium", Sodium },
                {"cholesterol", Cholesterol },
                {"sugar", Sugar },
                // TODO: Complete the dictionary 
            };
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

