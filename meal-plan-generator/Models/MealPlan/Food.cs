namespace meal_plan_generator.Models.MealPlan
{
    public class Food
    {
        public List<Nutrient> Nutrients { get; set; }

        internal decimal GetNutrientAmount(string name)
        {
            throw new NotImplementedException();
        }
    }
}
