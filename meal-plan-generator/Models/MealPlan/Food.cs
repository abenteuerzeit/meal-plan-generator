namespace meal_plan_generator.Models.MealPlan
{
    public class Food : EntityBase
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public List<Nutrient> Nutrients { get; set; }
        public double Servings { get; set; }
        public double ServingSize { get; set; }
        public int CaloriesPerServing { get; set; }

        public Food()
        {

        }

        public Food(string name, List<Nutrient> nutrients)
        {
            Name = name;
            Nutrients = nutrients;
        }


        internal float GetNutrientAmount(string name)
        {
            throw new NotImplementedException();
        }
    }
}
