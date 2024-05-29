using System;

//Reuven-Jon Kadalie ST10271460
namespace RecipeAppPart1
{
    class Ingredient : ICloneable
    {
        public string Name { get; private set; }
        public double Quantity { get; set; }
        public string Unit { get; private set; }
        public int Calories { get; private set; }
        public string FoodGroup { get; private set; }

        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ingredient name cannot be empty.", nameof(name));
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));
            if (string.IsNullOrWhiteSpace(unit))
                throw new ArgumentException("Unit cannot be empty.", nameof(unit));
            if (calories < 0)
                throw new ArgumentException("Calories cannot be negative.", nameof(calories));
            if (string.IsNullOrWhiteSpace(foodGroup))
                throw new ArgumentException("Food group cannot be empty.", nameof(foodGroup));

            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public Ingredient(Ingredient other)
        {
            Name = other.Name;
            Quantity = other.Quantity;
            Unit = other.Unit;
            Calories = other.Calories;
            FoodGroup = other.FoodGroup;
        }

        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name} ({Calories} calories, {FoodGroup})";
        }

        public object Clone()
        {
            return new Ingredient(this);
        }
    }
}



///////////////////////////////////////////////////////////////////////////////////////////////// 00 End Of File 00 ////////////////////////////////////////////////////////////////////////////////////////////////
