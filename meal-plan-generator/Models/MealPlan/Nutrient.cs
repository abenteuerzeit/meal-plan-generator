using meal_plan_generator.Models.USDA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace meal_plan_generator.Models.MealPlan
{
    public class Nutrient : EntityBase
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public float Quantity { get; set; }
        public int NutrientSettingsId { get; set; }
        public NutrientSettings Settings { get; set; }
        //public ComponentId ComponentId { get; internal set; }

        public Nutrient()
        {
            Name = "undefined";
            Unit = "undefined";
            Quantity = 0;
            Settings = new NutrientSettings();
        }

        public Nutrient(string name, string unit)
        {
            Name = name;
            Unit = unit;
            Quantity = 0;
            Settings = new NutrientSettings();
        }


        public Nutrient(string name, float quantity, string unit)
        {
            Name = name;
            Unit = unit;
            Quantity = quantity;
            Settings = new NutrientSettings();
        }

        //public Nutrient(ComponentId id)
        //{
        //    Name = "";
        //    Unit = "";
        //    Quantity = 0;
        //    Settings = GetNutrientDefault(id);
        //}
        //private static NutrientSettings GetNutrientDefault(ComponentId id)
        //{
        //    // TODO: Set default minimum values
        //    return new();
        //}


        public double GetNutrientScore()
        {
            // Use the appropriate function based on the current quantity of the nutrient
            if (Settings.IdealAmount < Quantity && Quantity <= Settings.UpperBound)
            {
                return GetNutrientLessThanMaxScore();
            }
            else if (Settings.LowerBound < Quantity && Quantity <= Settings.IdealAmount)
            {
                return GetNutrientGreaterThanMinScore();
            }
            else if (0 <= Quantity && Quantity <= Settings.LowerBound)
            {
                return GetNutrientLessThanMinScore();
            }
            else
            {
                // Return 0 if the current quantity is outside the valid range (less than 0)
                return 0;
            }
            throw new ArgumentOutOfRangeException(nameof(Quantity));
        }

        private double GetNutrientLessThanMinScore()
        {
            // Return a value based on the priority and current quantity if the current quantity is greater than or equal to 0
            return (Settings.Weight * (Quantity / Settings.LowerBound)) + Settings.Intercept;
        }

        private double GetNutrientGreaterThanMinScore()
        {
            // Return a value based on the priority and current quantity if the current quantity is greater than or equal to the ideal amount and greater than or equal to the lower bound
            return (Settings.Weight * (Quantity / Settings.IdealAmount)) + Settings.Intercept;
        }

        private double GetNutrientLessThanMaxScore()
        {
            // Return a value based on the priority and current quantity if the current quantity is greater than the ideal amount and less than or equal to the upper bound
            return -(Settings.Weight * (Quantity / Settings.UpperBound)) + Settings.Intercept;
        }

        public bool IsMet()
        {
            return Quantity >= Settings.LowerBound && Quantity <= Settings.UpperBound;
        }
    }
}
