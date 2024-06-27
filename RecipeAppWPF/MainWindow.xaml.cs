using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using RecipeAppPart1; // Ensure this namespace matches the one in your RecipeAppPart1 project
using Microsoft.VisualBasic;
using LiveCharts.Wpf.Charts.Base;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;
        private Recipe currentRecipe;

        public MainWindow()
        {
            InitializeComponent();
            recipes = Recipe.GetAllRecipes();
        }

        private void AddRecipe_Checked(object sender, RoutedEventArgs e)
        {
            currentRecipe = new Recipe();
            RecipeNameTextBox.Visibility = Visibility.Visible;
            IngredientNameTextBox.Visibility = Visibility.Visible;
            IngredientQuantityTextBox.Visibility = Visibility.Visible;
            IngredientUnitTextBox.Visibility = Visibility.Visible;
            IngredientCaloriesTextBox.Visibility = Visibility.Visible;
            IngredientFoodGroupTextBox.Visibility = Visibility.Visible;
            AddIngredientButton.Visibility = Visibility.Visible;
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentRecipe != null)
            {
                string ingredientName = IngredientNameTextBox.Text;
                if (double.TryParse(IngredientQuantityTextBox.Text, out double quantity) &&
                    int.TryParse(IngredientCaloriesTextBox.Text, out int calories))
                {
                    string unit = IngredientUnitTextBox.Text;
                    string foodGroup = IngredientFoodGroupTextBox.Text;

                    currentRecipe.AddIngredient(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
                    MessageBox.Show("Ingredient added successfully!");

                    // Clear the text boxes for the next ingredient
                    IngredientNameTextBox.Clear();
                    IngredientQuantityTextBox.Clear();
                    IngredientUnitTextBox.Clear();
                    IngredientCaloriesTextBox.Clear();
                    IngredientFoodGroupTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Invalid quantity or calories. Please enter valid numbers.");
                }
            }
        }

        private void DisplayIngredients_Checked(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = SelectRecipe();
            if (selectedRecipe != null)
            {
                MessageBox.Show(string.Join(Environment.NewLine, selectedRecipe.GetIngredients()), "Ingredients");
            }
        }

        private void DisplayCalories_Checked(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = SelectRecipe();
            if (selectedRecipe != null)
            {
                MessageBox.Show($"Total Calories: {selectedRecipe.CalculateTotalCalories()}", "Calories");
            }
        }

        private void DisplayFoodGroups_Checked(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = SelectRecipe();
            if (selectedRecipe != null)
            {
                MessageBox.Show(string.Join(Environment.NewLine, selectedRecipe.GetFoodGroups()), "Food Groups");
            }
        }

        private void Exit_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private Recipe SelectRecipe()
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available. Please add a recipe first.");
                return null;
            }
            else if (recipes.Count == 1)
            {
                return recipes[0];
            }
            else
            {
                string recipeNames = string.Join(Environment.NewLine, recipes.Select((r, i) => $"{i + 1}. {r.Name}"));


                string input = Interaction.InputBox($"Select a recipe by entering the number:\n{recipeNames}", "Select Recipe", "1");

                if (int.TryParse(input, out int index) && index > 0 && index <= recipes.Count)
                {
                    return recipes[index - 1];
                }
                else
                {
                    MessageBox.Show("Invalid selection. Please try again.");
                    return null;
                }
            }
        }
    }
}


