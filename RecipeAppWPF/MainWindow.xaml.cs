using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using RecipeAppPart1;
using Microsoft.VisualBasic;

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
            RecipeDetailsPanel.Visibility = Visibility.Visible;
            RecipeListBox.Visibility = Visibility.Collapsed;
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

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentRecipe != null && !string.IsNullOrEmpty(RecipeNameTextBox.Text))
            {
                currentRecipe.Name = RecipeNameTextBox.Text;
                recipes.Add(currentRecipe);
                MessageBox.Show("Recipe saved successfully!");

                RecipeNameTextBox.Clear();
                currentRecipe = new Recipe();
            }
            else
            {
                MessageBox.Show("Please enter a recipe name.");
            }
        }

        private void DisplayIngredients_Checked(object sender, RoutedEventArgs e)
        {
            RecipeListBox.Visibility = Visibility.Visible;
            RecipeDetailsPanel.Visibility = Visibility.Collapsed;
            RecipeListBox.ItemsSource = recipes.Select(r => r.Name).ToList();
        }

        private void DisplayCalories_Checked(object sender, RoutedEventArgs e)
        {
            RecipeListBox.Visibility = Visibility.Visible;
            RecipeDetailsPanel.Visibility = Visibility.Collapsed;
            RecipeListBox.ItemsSource = recipes.Select(r => r.Name).ToList();
        }

        private void DisplayFoodGroups_Checked(object sender, RoutedEventArgs e)
        {
            RecipeListBox.Visibility = Visibility.Visible;
            RecipeDetailsPanel.Visibility = Visibility.Collapsed;
            RecipeListBox.ItemsSource = recipes.Select(r => r.Name).ToList();
        }

        private void RecipeListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedIndex >= 0)
            {
                Recipe selectedRecipe = recipes[RecipeListBox.SelectedIndex];

                if (DisplayIngredients.IsChecked == true)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, selectedRecipe.GetIngredients()), "Ingredients");
                }
                else if (DisplayCalories.IsChecked == true)
                {
                    MessageBox.Show($"Total Calories: {selectedRecipe.CalculateTotalCalories()}", "Calories");
                }
                else if (DisplayFoodGroups.IsChecked == true)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, selectedRecipe.GetFoodGroups()), "Food Groups");
                }
            }
        }

        private void Exit_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

