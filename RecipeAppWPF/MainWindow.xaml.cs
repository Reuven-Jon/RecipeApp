using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using RecipeAppPart1; // Ensure this namespace correctly references where your Recipe and Ingredient classes are defined.

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;

        public MainWindow()
        {
            InitializeComponent();
            recipes = Recipe.GetAllRecipes();
            DisplayRecipes();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();
            recipe.EnterDetails();
            recipes.Add(recipe);
            DisplayRecipes();
        }

        private void DisplayRecipes()
        {
            RecipesListView.ItemsSource = null;
            RecipesListView.ItemsSource = recipes;
        }

        private void DisplayIngredients_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesListView.SelectedItem is Recipe selectedRecipe)
            {
                MessageBox.Show(string.Join(Environment.NewLine, selectedRecipe.GetIngredients()));
            }
        }

        private void DisplayCalories_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesListView.SelectedItem is Recipe selectedRecipe)
            {
                MessageBox.Show($"Total Calories: {selectedRecipe.CalculateTotalCalories()}");
            }
        }

        private void DisplayFoodGroups_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesListView.SelectedItem is Recipe selectedRecipe)
            {
                MessageBox.Show(string.Join(Environment.NewLine, selectedRecipe.GetFoodGroups()));
            }
        }

        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = IngredientFilter.Text;
            string foodGroup = ((ComboBoxItem)FoodGroupFilter.SelectedItem)?.Content.ToString();
            int maxCalories = int.TryParse(CaloriesFilter.Text, out int calories) ? calories : int.MaxValue;

            var filteredRecipes = Recipe.FilterRecipes(ingredientName, foodGroup, maxCalories);
            RecipesListView.ItemsSource = filteredRecipes;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
