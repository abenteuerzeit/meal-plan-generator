namespace meal_plan_generator.Models.MealPlan
{
    public class Food
    {
        public string Name { get; set; }
        public List<Nutrient> Nutrients { get; set; }

        public Food(string name, List<Nutrient> nutrients)
        {
            Name = name;
            Nutrients = nutrients;
        }

        internal decimal GetNutrientAmount(string name)
        {
            throw new NotImplementedException();
        }
    }
}
