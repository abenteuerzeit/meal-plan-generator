namespace meal_plan_generator.Models.MealPlan
{
    public class Food : EntityBase
    {
        public List<Nutrient> Nutrients { get; set; }

        internal decimal GetNutrientAmount(string name)
        {
            throw new NotImplementedException();
        }
    }
}
