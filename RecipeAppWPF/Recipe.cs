using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeAppPart1
{
    public class Recipe
    {
        private List<Ingredient> ingredients;
        public string Name { get; set; } // Changed from private set to public set

        private static List<Recipe> _recipes = new List<Recipe>();

        public Recipe()
        {
            ingredients = new List<Ingredient>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        public int CalculateTotalCalories()
        {
            return ingredients.Sum(ingredient => ingredient.Calories);
        }

        public static List<Recipe> GetAllRecipes()
        {
            if (_recipes.Count == 0)
            {
                var recipe1 = new Recipe { Name = "Sample Recipe" };
                recipe1.AddIngredient(new Ingredient("Flour", 2, "cups", 100, "Grain"));
                recipe1.AddIngredient(new Ingredient("Sugar", 1, "cup", 770, "Sweetener"));
                _recipes.Add(recipe1);
            }
            return _recipes;
        }

        public static List<Recipe> FilterRecipes(string ingredientName, string foodGroup, int maxCalories)
        {
            return _recipes.Where(recipe =>
                (string.IsNullOrEmpty(ingredientName) || recipe.ingredients.Any(ing => ing.Name.IndexOf(ingredientName, StringComparison.OrdinalIgnoreCase) >= 0)) &&
                (string.IsNullOrEmpty(foodGroup) || recipe.ingredients.Any(ing => ing.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase))) &&
                recipe.CalculateTotalCalories() <= maxCalories
            ).ToList();
        }

        public List<string> GetIngredients()
        {
            return ingredients.Select(ing => ing.ToString()).ToList();
        }

        public List<string> GetFoodGroups()
        {
            return ingredients.Select(ing => $"{ing.Name}: {ing.FoodGroup}").ToList();
        }

        public void EnterDetails()
        {
            Console.Write("Enter recipe name: ");
            Name = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount;
            while (!int.TryParse(Console.ReadLine(), out ingredientCount) || ingredientCount <= 0)
            {
                Console.WriteLine("Invalid number. Please enter a positive number.");
            }

            for (int i = 0; i < ingredientCount; i++)
            {
                EnterIngredientDetails(i + 1);
            }

            Console.WriteLine("Recipe details entered successfully.");
        }

        private void EnterIngredientDetails(int ingredientNumber)
        {
            Console.Write($"Enter ingredient {ingredientNumber} name: ");
            string ingredientName = Console.ReadLine();

            double quantity;
            while (true)
            {
                Console.Write($"Enter ingredient {ingredientNumber} quantity: ");
                if (double.TryParse(Console.ReadLine(), out quantity) && quantity > 0 && quantity < 1000)
                {
                    break;
                }
                Console.WriteLine("Invalid quantity. Please enter a number greater than 0 and less than 1000.");
            }

            Console.Write($"Enter ingredient {ingredientNumber} unit: ");
            string unit = Console.ReadLine();

            int calories;
            while (true)
            {
                Console.Write($"Enter ingredient {ingredientNumber} calories: ");
                if (int.TryParse(Console.ReadLine(), out calories) && calories > 0 && calories < 1000)
                {
                    break;
                }
                Console.WriteLine("Invalid calories. Please enter a number greater than 0 and less than 1000.");
            }

            Console.Write($"Enter ingredient {ingredientNumber} food group: ");
            string foodGroup = Console.ReadLine();

            ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
        }
    }
}

