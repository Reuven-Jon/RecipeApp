using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeAppPart1;

// Reuven-Jon Kadalie ST10271460
class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = new Recipe();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n1. Enter Recipe Details");
            Console.WriteLine("2. Display Recipe");
            Console.WriteLine("3. Scale Recipe");
            Console.WriteLine("4. Reset Quantities");
            Console.WriteLine("5. Clear Data");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    recipe.EnterDetails();
                    break;
                case 2:
                    recipe.DisplayRecipe();
                    break;
                case 3:
                    recipe.ScaleRecipe();
                    break;
                case 4:
                    recipe.ResetQuantities();
                    break;
                case 5:
                    recipe.ClearData();
                    break;
                case 6:
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

    ////////////////////////////////////////////////////////////////////////////// 00 End Of File 00 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}


