using System;
using System.Collections.Generic;
using System.Linq;
using global::meal_plan_generator.Models.MealPlan;
using meal_plan_generator.Models;
using Microsoft.EntityFrameworkCore;

namespace meal_plan_generator.Context
{
    public static class FakeData
    {
        private static readonly Random rnd = new();
        public static void Initialize(AppDbContext context, int amount = 10000)
        {
            if (!context.Foods.Any())
            {
                var foods = GenerateFoods(amount);
                context.Foods.AddRange(foods);
                context.SaveChanges();
            }
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
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Calcium", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Phosphorus", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Magnesium", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Potassium", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Sodium", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Iron", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Manganese", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Copper", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Zinc", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Selenium", Unit = "mcg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Vitamin A", Unit = "IU" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Vitamin C", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Vitamin E", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Vitamin K", Unit = "mcg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Thiamin", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Roboflavin", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Niacin", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Pantothenic Acid", Unit = "mg" },
                    new Nutrient { CurrentNutrientQuantity = rnd.Next(0, 1000), Name = "Folate", Unit = "mcg" }
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

