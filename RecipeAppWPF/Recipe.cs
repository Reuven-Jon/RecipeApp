using System;
using System.Collections.Generic;
using System.Linq;

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
                (string.IsNullOrEmpty(ingredientName) || recipe.ingredients.Any(ing => ing.Name.Contains(ingredientName, StringComparison.OrdinalIgnoreCase))) &&
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

        internal void EnterDetails()
        {
            throw new NotImplementedException();
        }
    }
}
