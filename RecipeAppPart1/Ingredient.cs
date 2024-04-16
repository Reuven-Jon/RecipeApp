using System;

// Reuven-Jon Kadalie ST10271460

namespace RecipeAppPart1
{
    // Define a class to represent an ingredient used in a recipe
    class Ingredient : ICloneable
    {
        // Properties to store the name, quantity, and unit of the ingredient
        public string Name { get; private set; } // Name of the ingredient.
        public double Quantity { get; set; } // Quantity of the ingredient.
        public string Unit { get; private set; } // Unit of measurement for the quantity.

        // Constructor to initialize an ingredient with a name, quantity, and unit.
        public Ingredient(string name, double quantity, string unit)
        {
            // Validate the input before assignment.
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ingredient name cannot be empty.", nameof(name));
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));
            if (string.IsNullOrWhiteSpace(unit))
                throw new ArgumentException("Unit cannot be empty.", nameof(unit));

            Name = name; // Initialize the name property.
            Quantity = quantity; // Initialize the quantity property.
            Unit = unit; // Initialize the unit property.
        }

        // Copy constructor for type-safe cloning.
        public Ingredient(Ingredient other)
        {
            Name = other.Name;
            Quantity = other.Quantity;
            Unit = other.Unit;
        }

        // Method to display the ingredient in a formatted manner.
        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name}";
        }

        // Implementation of the ICloneable interface.
        public object Clone()
        {
            return new Ingredient(this);
        }
    }
}


///////////////////////////////////////////////////////////////////////////////////////////////// 00 End Of File 00 ////////////////////////////////////////////////////////////////////////////////////////////////
