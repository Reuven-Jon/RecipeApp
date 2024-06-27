using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RecipeAppPart1;
using Microsoft.VisualBasic;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;
        private Recipe currentRecipe;
        private int ingredientCount = 0;

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
            IngredientsPanel.Children.Clear();
            ingredientCount = 0;
            AddIngredientInputFields();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            AddIngredientInputFields();
        }

        private void AddIngredientInputFields()
        {
            ingredientCount++;

            // Add Ingredient Name
            var ingredientNameLabel = new TextBlock { Text = $"Enter name of Ingredient {ingredientCount}" };
            var ingredientNameTextBox = new TextBox { Name = $"IngredientNameTextBox{ingredientCount}", Width = 200, Margin = new Thickness(5) };
            IngredientsPanel.Children.Add(ingredientNameLabel);
            IngredientsPanel.Children.Add(ingredientNameTextBox);

            // Add Ingredient Quantity
            var ingredientQuantityLabel = new TextBlock { Text = $"Enter Quantity of Ingredient {ingredientCount}" };
            var ingredientQuantityTextBox = new TextBox { Name = $"IngredientQuantityTextBox{ingredientCount}", Width = 200, Margin = new Thickness(5) };
            IngredientsPanel.Children.Add(ingredientQuantityLabel);
            IngredientsPanel.Children.Add(ingredientQuantityTextBox);

            // Add Ingredient Unit
            var ingredientUnitLabel = new TextBlock { Text = $"Enter Unit of Ingredient {ingredientCount}" };
            var ingredientUnitTextBox = new TextBox { Name = $"IngredientUnitTextBox{ingredientCount}", Width = 200, Margin = new Thickness(5) };
            IngredientsPanel.Children.Add(ingredientUnitLabel);
            IngredientsPanel.Children.Add(ingredientUnitTextBox);

            // Add Ingredient Calories
            var ingredientCaloriesLabel = new TextBlock { Text = $"Enter Calories of Ingredient {ingredientCount}" };
            var ingredientCaloriesTextBox = new TextBox { Name = $"IngredientCaloriesTextBox{ingredientCount}", Width = 200, Margin = new Thickness(5) };
            IngredientsPanel.Children.Add(ingredientCaloriesLabel);
            IngredientsPanel.Children.Add(ingredientCaloriesTextBox);

            // Add Ingredient Food Group
            var ingredientFoodGroupLabel = new TextBlock { Text = $"Enter Food Group of Ingredient {ingredientCount}" };
            var ingredientFoodGroupTextBox = new TextBox { Name = $"IngredientFoodGroupTextBox{ingredientCount}", Width = 200, Margin = new Thickness(5) };
            IngredientsPanel.Children.Add(ingredientFoodGroupLabel);
            IngredientsPanel.Children.Add(ingredientFoodGroupTextBox);
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentRecipe != null && !string.IsNullOrEmpty(RecipeNameTextBox.Text))
            {
                currentRecipe.Name = RecipeNameTextBox.Text;

                for (int i = 1; i <= ingredientCount; i++)
                {
                    var ingredientName = (TextBox)IngredientsPanel.FindName($"IngredientNameTextBox{i}");
                    var ingredientQuantity = (TextBox)IngredientsPanel.FindName($"IngredientQuantityTextBox{i}");
                    var ingredientUnit = (TextBox)IngredientsPanel.FindName($"IngredientUnitTextBox{i}");
                    var ingredientCalories = (TextBox)IngredientsPanel.FindName($"IngredientCaloriesTextBox{i}");
                    var ingredientFoodGroup = (TextBox)IngredientsPanel.FindName($"IngredientFoodGroupTextBox{i}");

                    if (ingredientName != null && ingredientQuantity != null && ingredientUnit != null && ingredientCalories != null && ingredientFoodGroup != null)
                    {
                        if (double.TryParse(ingredientQuantity.Text, out double quantity) &&
                            int.TryParse(ingredientCalories.Text, out int calories))
                        {
                            currentRecipe.AddIngredient(new Ingredient(
                                ingredientName.Text,
                                quantity,
                                ingredientUnit.Text,
                                calories,
                                ingredientFoodGroup.Text));
                        }
                        else
                        {
                            MessageBox.Show($"Invalid quantity or calories for Ingredient {i}. Please enter valid numbers.");
                            return;
                        }
                    }
                }

                recipes.Add(currentRecipe);
                MessageBox.Show("Recipe saved successfully!");

                RecipeNameTextBox.Clear();
                IngredientsPanel.Children.Clear();
                ingredientCount = 0;
                AddIngredientInputFields();
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
