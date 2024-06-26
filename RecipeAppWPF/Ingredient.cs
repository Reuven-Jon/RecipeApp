
using System;
using System.Collections.Generic;

public class Ingredient : ICloneable
{
    public string Name { get; private set; }
    public double Quantity { get; set; }
    public double OriginalQuantity { get; private set; }
    public string Unit { get; private set; }
    public int Calories { get; private set; }
    public string FoodGroup { get; private set; }

    // Define the static list of ingredients
    private static List<Ingredient> _ingredients = new List<Ingredient>();

    public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
    {
        Name = name;
        Quantity = OriginalQuantity = quantity;
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

    public static List<Ingredient> GetAllIngredients()
    {
        // Initialize with sample data if empty
        if (_ingredients.Count == 0)
        {
            _ingredients.Add(new Ingredient("Flour", 2, "cups", 100, "Grain"));
            _ingredients.Add(new Ingredient("Sugar", 1, "cup", 770, "Sweetener"));
            // Add more sample ingredients as needed
        }
        return _ingredients;
    }
}




///////////////////////////////////////////////////////////////////////////////////////////////// 00 End Of File 00 ////////////////////////////////////////////////////////////////////////////////////////////////
