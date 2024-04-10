using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeAppPart1;

// Reuven-Jon Kadalie ST10271460
namespace RecipeAppPart1
{
    //Define a class to represent an ingredient used in a recipe
    class Ingredient
    {
        //Properties to store the name, quantity, and unit of the ingredient
        public string Name { get; set; } //name of ingredient
        public double Quantity { get; set; } //Quantity of the ingredients
        public string Unit { get; set; } // The unit of measurement for the quantities

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;//Initialise the Name property with the provided name
            Quantity = quantity; //Initialise the Quantity property with the provided quantity
            Unit = unit; //Initialise the uinit property with the provided unit
        }
    }
}
///////////////////////////////////////////////////////////////////////////////////////////////// 00 End Of File 00 ////////////////////////////////////////////////////////////////////////////////////////////////
