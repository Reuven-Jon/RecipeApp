using System;
using System.Collections.Generic;
using RecipeAppPart1;

class Program
{
    delegate void DisplayRecipeDelegate(Recipe recipe);

    static void Main(string[] args)
    {
        List<Recipe> recipes = new List<Recipe>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n1. Enter Recipe Details");
            Console.WriteLine("2. Display Recipe");
            Console.WriteLine("3. Scale Recipe");
            Console.WriteLine("4. Reset Quantities");
            Console.WriteLine("5. Clear Data");
            Console.WriteLine("6. List All Recipes");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Recipe recipe = new Recipe();
                    recipe.EnterDetails();
                    recipes.Add(recipe);
                    break;
                case 2:
                    Console.Write("Enter recipe name to display: ");
                    string name = Console.ReadLine();
                    DisplayRecipeDelegate displayRecipe = DisplayRecipe;
                    Recipe selectedRecipe = recipes.Find(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                    if (selectedRecipe != null)
                    {
                        displayRecipe(selectedRecipe);
                    }
                    else
                    {
                        Console.WriteLine("Recipe not found.");
                    }
                    break;
                case 3:
                    // Scale Recipe logic here
                    break;
                case 4:
                    // Reset Quantities logic here
                    break;
                case 5:
                    // Clear Data logic here
                    break;
                case 6:
                    ListAllRecipes(recipes);
                    break;
                case 7:
                    Console.Write("Are you sure you want to exit? (Y/N): ");
                    string exitChoice = Console.ReadLine().ToUpper();
                    if (exitChoice == "Y")
                    {
                        exit = true;
                        Console.WriteLine("Exiting...");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void DisplayRecipe(Recipe recipe)
    {
        recipe.DisplayRecipe();
    }

    static void ListAllRecipes(List<Recipe> recipes)
    {
        recipes.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));
        foreach (var recipe in recipes)
        {
            Console.WriteLine(recipe.Name);
        }
    }
}

////////////////////////////////////////////////////////////////////////////// 00 End Of File 00 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



