using System;
using System.Collections.Generic;

//Reuven-Jon Kadalie ST10271460
namespace RecipeAppPart1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid choice, please enter a number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

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
                        Recipe selectedRecipe = recipes.Find(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (selectedRecipe != null)
                        {
                            selectedRecipe.DisplayRecipe();
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;
                    case 3:
                        Console.Write("Enter recipe name to scale: ");
                        string scaleName = Console.ReadLine();
                        Recipe scaleRecipe = recipes.Find(r => r.Name.Equals(scaleName, StringComparison.OrdinalIgnoreCase));
                        if (scaleRecipe != null)
                        {
                            Console.Write("Enter scale factor: ");
                            double scaleFactor = double.Parse(Console.ReadLine());
                            scaleRecipe.ScaleRecipe(scaleFactor);
                            Console.WriteLine("Recipe scaled successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;
                    case 4:
                        Console.Write("Enter recipe name to reset quantities: ");
                        string resetName = Console.ReadLine();
                        Recipe resetRecipe = recipes.Find(r => r.Name.Equals(resetName, StringComparison.OrdinalIgnoreCase));
                        if (resetRecipe != null)
                        {
                            resetRecipe.ResetQuantities();
                            Console.WriteLine("Quantities reset successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
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



