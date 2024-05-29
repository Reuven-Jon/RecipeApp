using System;
using System.Collections.Generic;

//Reuven-Jon Kadalie ST10271460 
namespace RecipeAppPart1
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            // Create a list to store all the recipes
            List<Recipe> recipes = new List<Recipe>();
            
            bool exit = false;

            
            while (!exit)
            {
                
                Console.Clear();
                // Display the main menu
                Console.WriteLine("\n1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                // Try to parse the user's choice to an integer
                if (!int.TryParse(input, out int choice))
                {
                    // If the input is not a number, display an error message
                    Console.WriteLine("Invalid choice, please enter a number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                // Handle the user's choice
                switch (choice)
                {
                    case 1:
                        // Create a new recipe and enter its details
                        Recipe recipe = new Recipe();
                        recipe.EnterDetails();
                        // Add the new recipe to the list of recipes
                        recipes.Add(recipe);
                        break;
                    case 2:
                        // Check if there are any recipes
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes found.");
                            break;
                        }

                        // Display all the recipes
                        Console.WriteLine("Available recipes:");
                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                        }

                        // Ask the user to select a recipe
                        Console.Write("Enter the number of the recipe to display: ");
                        if (!int.TryParse(Console.ReadLine(), out int recipeNumber) || recipeNumber < 1 || recipeNumber > recipes.Count)
                        {
                            Console.WriteLine("Invalid choice, please enter a valid number.");
                            break;
                        }

                        // Display the selected recipe
                        recipes[recipeNumber - 1].DisplayRecipe();
                        break;

                    case 3:
                        // Ask the user for the name of the recipe to scale
                        Console.Write("Enter recipe name to scale: ");
                        string scaleName = Console.ReadLine();
                        // Find the recipe in the list of recipes
                        Recipe scaleRecipe = recipes.Find(r => r.Name.Equals(scaleName, StringComparison.OrdinalIgnoreCase));
                        if (scaleRecipe != null)
                        {
                            // If the recipe is found, ask the user for the scale factor
                            Console.Write("Enter scale factor: ");
                            double scaleFactor = double.Parse(Console.ReadLine());
                            // Scale the recipe
                            scaleRecipe.ScaleRecipe(scaleFactor);
                            Console.WriteLine("Recipe scaled successfully.");
                        }
                        else
                        {
                            // If the recipe is not found, display an error message
                            Console.WriteLine("Recipe not found.");
                        }
                        break;
                    case 4:
                        // Ask the user for the name of the recipe to reset quantities
                        Console.Write("Enter recipe name to reset quantities: ");
                        string resetName = Console.ReadLine();
                        // Find the recipe in the list of recipes
                        Recipe resetRecipe = recipes.Find(r => r.Name.Equals(resetName, StringComparison.OrdinalIgnoreCase));
                        if (resetRecipe != null)
                        {
                            // If the recipe is found, reset its quantities
                            resetRecipe.ResetQuantities();
                            Console.WriteLine("Quantities reset successfully.");
                        }
                        else
                        {
                            
                            Console.WriteLine("Recipe not found.");
                        }
                        break;
                    case 5:
                        // Exit the application
                        exit = true;
                        break;
                    default:
                        // If the user's choice is not recognized, display an error message
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}



////////////////////////////////////////////////////////////////////////////// 00 End Of File 00 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



