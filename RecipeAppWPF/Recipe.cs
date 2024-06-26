using System;
using System.Collections.Generic;
using System.Linq;

//Reuven-Jon Kadalie ST10271460
namespace RecipeAppPart1
{
    public class Recipe
    {
        private List<Ingredient> ingredients;
        public string Name { get; private set; }

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
            // Prompt the user to enter the recipe name.
            Console.Write("Enter recipe name: ");
            Name = Console.ReadLine();

            // Prompt the user to enter the number of ingredients.
            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            // Enter details for each ingredient.
            for (int i = 0; i < ingredientCount; i++)
            {
                EnterIngredientDetails(i + 1);
            }

            Console.WriteLine("Recipe details entered successfully.");
        }

        private void EnterIngredientDetails(int ingredientNumber)
        {
            // Prompt the user to enter the ingredient name.
            Console.Write($"Enter ingredient {ingredientNumber} name: ");
            string ingredientName = Console.ReadLine();

            // Prompt the user to enter the ingredient quantity.
            Console.Write($"Enter ingredient {ingredientNumber} quantity: ");
            double quantity = double.Parse(Console.ReadLine());

            // Prompt the user to enter the ingredient unit.
            Console.Write($"Enter ingredient {ingredientNumber} unit: ");
            string unit = Console.ReadLine();

            // Prompt the user to enter the ingredient calories.
            Console.Write($"Enter ingredient {ingredientNumber} calories: ");
            int calories = int.Parse(Console.ReadLine());

            // Prompt the user to enter the ingredient food group.
            Console.Write($"Enter ingredient {ingredientNumber} food group: ");
            string foodGroup = Console.ReadLine();

            // Add the new ingredient to the ingredients list.
            ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
        }
    }
}
