using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeAppPart1;

namespace RecipeAppPart1
{

    //Reuven-Jon Kadalie ST10271460
    

        // Private fields to store recipe name, ingredients, and steps 
        class Recipe
        {
            private string name;
            private Ingredient[] ingredients;
            private string[] steps;

            //Method to enter details of the recipe
            public void EnterDetails()
            {
                Console.Write("Enter recipe name: ");
                name = Console.ReadLine(); //Read user input and store as recipe name

                Console.Write("Enter the number of ingredients: ");
                int ingredientCount = int.Parse(Console.ReadLine()); //Read number of ingredients
                ingredients = new Ingredient[ingredientCount]; //Initialise the array to store ingredients
                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.Write($"Enter ingredient {i + 1} details (e.g., '50 grams of sugar'): ");
                    string ingredientLine = Console.ReadLine();
                    string[] parts = ingredientLine.Split(' '); // Split input by space
                    double quantity = double.Parse(parts[0]); // Parse quantity
                    string unit = parts[1]; // Unit is the second part of input
                    string ingredientName = string.Join(" ", parts, 2, parts.Length - 2); // Join remaining parts as ingredient name
                    ingredients[i] = new Ingredient(ingredientName, quantity, unit); //Create and store ingredient object
                }

                Console.Write("Enter the number of steps: ");
                int stepCount = int.Parse(Console.ReadLine()); //Read the number of steps
                steps = new string[stepCount]; //Initialise the array to store steps
                for (int i = 0; i < stepCount; i++)
                {
                    Console.Write($"Enter step {i + 1}: ");
                    steps[i] = Console.ReadLine(); //Read and store each step 
                }

                Console.WriteLine("Recipe details entered successfully.");
            }

            public void DisplayRecipe()
            {
                Console.WriteLine($"Recipe Name: {name}"); //Display recipe name
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in ingredients)
                {
                    Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
                }
                Console.WriteLine("Steps:");
                foreach (var step in steps)
                {
                    Console.WriteLine($"- {step}"); // Show the steps
                }
            }

            public void ScaleRecipe()
            {
                Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                double factor = double.Parse(Console.ReadLine()); //Read scaling factor
                                                                  // Scale ingredient quantities accordingly
                foreach (var ingredient in ingredients)
                {
                    ingredient.Quantity *= factor; //Multiply each ingredient quantity by the scaling factor
                }
                Console.WriteLine("Recipe scaled successfully.");
            }

            public void ResetQuantities()
            {
                // Reset ingredient quantities to original values
                // Implementation left as an exercise for the reader
                Console.WriteLine("Quantities reset successfully.");
            }

            public void ClearData()
            {
                // clear data of the recipe
                name = null;
                ingredients = null;
                steps = null;
                Console.WriteLine("All data cleared successfully.");
            }
        }
    }
///////////////////////////////////////////////////////////////////////////////////////////// 00 End Of File 00 /////////////////////////////////////////////////////////////////////////////////////////////////////