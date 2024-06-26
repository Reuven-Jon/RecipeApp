using System.Collections.Generic;
using System.Linq; // Required for LINQ operations

namespace RecipeAppPart1
{
    class Recipe
    {
        // Assuming Ingredient class and other necessary members are defined elsewhere
        private List<Ingredient> ingredients; // Ensure this is accessible for FilterRecipes
        public string Name { get; private set; } // Example property

        private static List<Recipe> _recipes = new List<Recipe>();

        public Recipe()
        {
            ingredients = new List<Ingredient>(); // Initialize the ingredients list
        }

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        public int CalculateTotalCalories()
        {
            // Assuming Ingredient has a Calories property
            return ingredients.Sum(ingredient => ingredient.Calories);
        }

        public static List<Recipe> GetAllRecipes()
        {
            // Initialize with sample data if empty
            if (_recipes.Count == 0)
            {
                // Create and add sample recipes
                var recipe1 = new Recipe();
                recipe1.AddIngredient(new Ingredient("Flour", 2, "cups", 100, "Grain"));
                recipe1.AddIngredient(new Ingredient("Sugar", 1, "cup", 770, "Sweetener"));
                // Add steps and other details as needed
                _recipes.Add(recipe1);

                // Add more recipes as needed
            }
            return _recipes;
        }

        // Method to filter recipes by ingredient name, food group, or max calories
        public static List<Recipe> FilterRecipes(string ingredientName, string foodGroup, int maxCalories)
        {
            return _recipes.Where(recipe =>
                (string.IsNullOrEmpty(ingredientName) || recipe.ingredients.Any(ing => ing.Name.Contains(ingredientName))) &&
                (string.IsNullOrEmpty(foodGroup) || recipe.ingredients.Any(ing => ing.FoodGroup == foodGroup)) &&
                (maxCalories == 0 || recipe.CalculateTotalCalories() <= maxCalories)
            ).ToList();
        }
    }
}







///////////////////////////////////////////////////////////////////////////////////////////// 00 End Of File 00 /////////////////////////////////////////////////////////////////////////////////////////////////////