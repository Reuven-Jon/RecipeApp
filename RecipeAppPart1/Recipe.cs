using System;
using System.Collections.Generic;

namespace RecipeAppPart1
{
    class Recipe
    {
        public string Name { get; private set; }
        private List<Ingredient> ingredients;
        private string[] steps;

        public Recipe()
        {
            ingredients = new List<Ingredient>();
        }

        public void EnterDetails()
        {
            Console.Write("Enter recipe name: ");
            Name = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write($"Enter ingredient {i + 1} name: ");
                string ingredientName = Console.ReadLine();

                Console.Write($"Enter ingredient {i + 1} quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter ingredient {i + 1} unit: ");
                string unit = Console.ReadLine();

                Console.Write($"Enter ingredient {i + 1} calories: ");
                int calories = int.Parse(Console.ReadLine());

                Console.Write($"Enter ingredient {i + 1} food group: ");
                string foodGroup = Console.ReadLine();

                ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
            }

            Console.Write("Enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());
            steps = new string[stepCount];
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine("Recipe details entered successfully.");
        }

        public void DisplayRecipe()
        {
            if (Name == null || ingredients == null || steps == null)
            {
                Console.WriteLine("No recipe details found. Please enter recipe details first.");
                EnterDetails();
            }
            else
            {
                Console.WriteLine($"Recipe Name: {Name}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in ingredients)
                {
                    Console.WriteLine($"- {ingredient}");
                }
                Console.WriteLine("Steps:");
                foreach (var step in steps)
                {
                    Console.WriteLine($"- {step}");
                }
                Console.WriteLine($"Total Calories: {CalculateTotalCalories()}");
                if (CalculateTotalCalories() > 300)
                {
                    Console.WriteLine("Warning: This recipe exceeds 300 calories.");
                }
            }
        }

        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        // Other methods (ScaleRecipe, ResetQuantities, ClearData) remain unchanged...
    }
}


///////////////////////////////////////////////////////////////////////////////////////////// 00 End Of File 00 /////////////////////////////////////////////////////////////////////////////////////////////////////