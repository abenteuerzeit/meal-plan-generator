using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using global::meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Context
{
    public static class FakeData
    {
        private static readonly Random rnd = new();
        public static void Initialize(AppDbContext context, int amount = 2000)
        {
            var foods = GenerateFoods(amount);
            context.Foods.AddRange(foods);
            context.SaveChanges();
        }

        private static IEnumerable<Food> GenerateFoods(int amount)
        {
            var foods = new List<Food>();

            for (int i = 0; i < amount; i++)
            {
                var food = new Food(GetFakeFoodName(), GetFakeNutrients());
                foods.Add(food);
            }
            return foods;

            static List<Nutrient> GetFakeNutrients()
            {
                return new List<Nutrient>()
                {
                    new Nutrient("Calcium", "mg" ) { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Phosphorus", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Magnesium", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Potassium", "mg" ) { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Sodium", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Iron", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Manganese", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Copper", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Zinc", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Selenium", "mcg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Vitamin A", "IU") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Vitamin C", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Vitamin E", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Vitamin K", "mcg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Thiamin", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Roboflavin", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Niacin", "mg" ) { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Pantothenic Acid", "mg") { Quantity = rnd.Next(0, 1000) },
                    new Nutrient("Folate", "mcg") { Quantity = rnd.Next(0, 1000) }
                };
            }
        }

        static string GetFakeFoodName()
        {
            string[] syllables = { "ba", "be", "bi", "bo", "bu", "ca", "ce", "ci", "co", "cu", "da", "de", "di", "do", "du", "fa", "fe", "fi", "fo", "fu", "ga", "ge", "gi", "go", "gu", "ha", "he", "hi", "ho", "hu", "ja", "je", "ji", "jo", "ju", "ka", "ke", "ki", "ko", "ku", "la", "le", "li", "lo", "lu", "ma", "me", "mi", "mo", "mu", "na", "ne", "ni", "no", "nu", "pa", "pe", "pi", "po", "pu", "qa", "qe", "qi", "qo", "qu", "ra", "re", "ri", "ro", "ru", "sa", "se", "si", "so", "su", "ta", "te", "ti", "to", "tu", "va", "ve", "vi", "vo", "vu", "wa", "we", "wi", "wo", "wu", "xa", "xe", "xi", "xo", "xu", "ya", "ye", "yi", "yo", "yu", "za", "ze", "zi", "zo", "zu", "á", "é", "í", "ó", "ú", "ć", "ę", "ł", "ń", "ś", "ź", "ż", "à", "â", "ç", "è", "ê", "ë", "î", "ï", "ô", "ù", "û", "ü", "Ä", "Ö", "Ü", "ß" };
            string name = "";

            for (int i = 0; i < rnd.Next(2, 5); i++)
            {
                name += syllables[rnd.Next(syllables.Length)];
            }
            return name;
        }
    }
}

