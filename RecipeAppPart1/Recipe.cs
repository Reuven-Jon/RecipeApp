using System;
using System.Collections.Generic;

//Reuven-Jon Kadalie ST10271460
namespace RecipeAppPart1
{
    // The Recipe class represents a recipe in the application.
    class Recipe
    {
        // Properties of the Recipe class.
        public string Name { get; private set; }
        private List<Ingredient> ingredients; // List of ingredients in the recipe.
        private string[] steps; // Steps to prepare the recipe.

        // Constructor for the Recipe class.
        public Recipe()
        {
            // Initialize the ingredients list.
            ingredients = new List<Ingredient>();
        }

        // Method to enter details for a single ingredient.
        public void EnterIngredientDetails(int ingredientNumber)
        {
            // Prompt the user to enter the ingredient name.
            Console.Write($"Enter ingredient {ingredientNumber} name: ");
            string ingredientName = Console.ReadLine();

            // Prompt the user to enter the ingredient quantity.
            // Use a try-catch block to handle invalid input.
            double quantity;
            while (true)
            {
                try
                {
                    Console.Write($"Enter ingredient {ingredientNumber} quantity: ");
                    quantity = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            // Prompt the user to enter the ingredient unit.
            Console.Write($"Enter ingredient {ingredientNumber} unit: ");
            string unit = Console.ReadLine();

            // Prompt the user to enter the ingredient calories.
            // Use a try-catch block to handle invalid input.
            int calories;
            while (true)
            {
                try
                {
                    Console.Write($"Enter ingredient {ingredientNumber} calories: ");
                    calories = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            // Prompt the user to enter the ingredient food group.
            Console.Write($"Enter ingredient {ingredientNumber} food group: ");
            string foodGroup = Console.ReadLine();

            // Add the new ingredient to the ingredients list.
            ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
        }

        // Method to enter details for the recipe.
        public void EnterDetails()
        {
            // Prompt the user to enter the recipe name.
            Console.Write("Enter recipe name: ");
            Name = Console.ReadLine();

            // Prompt the user to enter the number of ingredients.
            // Then call the EnterIngredientDetails method for each ingredient.
            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < ingredientCount; i++)
            {
                EnterIngredientDetails(i + 1);
            }

            // Prompt the user to enter the number of steps.
            // Then prompt the user to enter each step.
            Console.Write("Enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());
            steps = new string[stepCount];
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            // Notify the user that the recipe details have been entered successfully.
            Console.WriteLine("Recipe details entered successfully.");
        }

        // Method to display the recipe.
        public void DisplayRecipe()
        {
            // If the recipe details have not been entered, prompt the user to enter them.
            // Otherwise, display the recipe details.
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

        // Method to calculate the total calories in the recipe.
        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

    }
    public void ResetQuantities()
    {
        foreach (var ingredient in ingredients)
        {
            ingredient.Quantity = ingredient.OriginalQuantity;
        }
    }

    // Method to scale the recipe by a given factor.
    public void ScaleRecipe(double scale)
    {
        foreach (var ingredient in ingredients)
        {
            ingredient.Quantity *= scale;
        }
    }
}





///////////////////////////////////////////////////////////////////////////////////////////// 00 End Of File 00 /////////////////////////////////////////////////////////////////////////////////////////////////////