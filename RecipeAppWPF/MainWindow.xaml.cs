using System;
using System.Collections.Generic;
using System.Windows;
using RecipeAppPart1; // Ensure this namespace correctly references where your Recipe and Ingredient classes are defined.

//Reuven-Jon Kadalie ST10271460
namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;

        public MainWindow()
        {
            InitializeComponent();
            recipes = Recipe.GetAllRecipes();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();
            recipe.EnterDetails();
            recipes.Add(recipe);
            MessageBox.Show("Recipe added successfully!");
        }

        private void DisplayIngredients_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add a recipe first.");
                return;
            }

            Recipe selectedRecipe = SelectRecipe();
            if (selectedRecipe != null)
            {
                MessageBox.Show(string.Join(Environment.NewLine, selectedRecipe.GetIngredients()), "Ingredients");
            }
        }

        private void DisplayCalories_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add a recipe first.");
                return;
            }

            Recipe selectedRecipe = SelectRecipe();
            if (selectedRecipe != null)
            {
                MessageBox.Show($"Total Calories: {selectedRecipe.CalculateTotalCalories()}", "Calories");
            }
        }

        private void DisplayFoodGroups_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add a recipe first.");
                return;
            }

            Recipe selectedRecipe = SelectRecipe();
            if (selectedRecipe != null)
            {
                MessageBox.Show(string.Join(Environment.NewLine, selectedRecipe.GetFoodGroups()), "Food Groups");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private Recipe SelectRecipe()
        {
            // Simple selection for demo purposes. Replace with actual selection logic as needed.
            if (recipes.Count == 1)
            {
                return recipes[0];
            }
            else
            {
                // Example: Prompt user to select a recipe from a list
                // For now, we return the first recipe
                return recipes[0];
            }
        }
    }
}
