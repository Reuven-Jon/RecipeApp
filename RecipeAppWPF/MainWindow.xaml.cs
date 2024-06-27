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
            var ingredientNameLabel = new TextBlock { Text = $"Enter name of Ingredient {ingredientCount}", FontSize = 16, FontWeight = FontWeights.Bold };
            var ingredientNameTextBox = new TextBox { Width = 300, Height = 30, Margin = new Thickness(10) };
            ingredientNameTextBox.Name = $"IngredientNameTextBox{ingredientCount}";
            IngredientsPanel.Children.Add(ingredientNameLabel);
            IngredientsPanel.Children.Add(ingredientNameTextBox);
            RegisterName(ingredientNameTextBox.Name, ingredientNameTextBox);

            // Add Ingredient Quantity
            var ingredientQuantityLabel = new TextBlock { Text = $"Enter Quantity of Ingredient {ingredientCount}", FontSize = 16, FontWeight = FontWeights.Bold };
            var ingredientQuantityTextBox = new TextBox { Width = 300, Height = 30, Margin = new Thickness(10) };
            ingredientQuantityTextBox.Name = $"IngredientQuantityTextBox{ingredientCount}";
            IngredientsPanel.Children.Add(ingredientQuantityLabel);
            IngredientsPanel.Children.Add(ingredientQuantityTextBox);
            RegisterName(ingredientQuantityTextBox.Name, ingredientQuantityTextBox);

            // Add Ingredient Unit
            var ingredientUnitLabel = new TextBlock { Text = $"Enter Unit of Ingredient {ingredientCount}", FontSize = 16, FontWeight = FontWeights.Bold };
            var ingredientUnitTextBox = new TextBox { Width = 300, Height = 30, Margin = new Thickness(10) };
            ingredientUnitTextBox.Name = $"IngredientUnitTextBox{ingredientCount}";
            IngredientsPanel.Children.Add(ingredientUnitLabel);
            IngredientsPanel.Children.Add(ingredientUnitTextBox);
            RegisterName(ingredientUnitTextBox.Name, ingredientUnitTextBox);

            // Add Ingredient Calories
            var ingredientCaloriesLabel = new TextBlock { Text = $"Enter Calories of Ingredient {ingredientCount}", FontSize = 16, FontWeight = FontWeights.Bold };
            var ingredientCaloriesTextBox = new TextBox { Width = 300, Height = 30, Margin = new Thickness(10) };
            ingredientCaloriesTextBox.Name = $"IngredientCaloriesTextBox{ingredientCount}";
            IngredientsPanel.Children.Add(ingredientCaloriesLabel);
            IngredientsPanel.Children.Add(ingredientCaloriesTextBox);
            RegisterName(ingredientCaloriesTextBox.Name, ingredientCaloriesTextBox);

            // Add Ingredient Food Group
            var ingredientFoodGroupLabel = new TextBlock { Text = $"Enter Food Group of Ingredient {ingredientCount}", FontSize = 16, FontWeight = FontWeights.Bold };
            var ingredientFoodGroupTextBox = new TextBox { Width = 300, Height = 30, Margin = new Thickness(10) };
            ingredientFoodGroupTextBox.Name = $"IngredientFoodGroupTextBox{ingredientCount}";
            IngredientsPanel.Children.Add(ingredientFoodGroupLabel);
            IngredientsPanel.Children.Add(ingredientFoodGroupTextBox);
            RegisterName(ingredientFoodGroupTextBox.Name, ingredientFoodGroupTextBox);
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentRecipe != null && !string.IsNullOrEmpty(RecipeNameTextBox.Text))
            {
                currentRecipe.Name = RecipeNameTextBox.Text;

                for (int i = 1; i <= ingredientCount; i++)
                {
                    var ingredientNameTextBox = (TextBox)FindName($"IngredientNameTextBox{i}");
                    var ingredientQuantityTextBox = (TextBox)FindName($"IngredientQuantityTextBox{i}");
                    var ingredientUnitTextBox = (TextBox)FindName($"IngredientUnitTextBox{i}");
                    var ingredientCaloriesTextBox = (TextBox)FindName($"IngredientCaloriesTextBox{i}");
                    var ingredientFoodGroupTextBox = (TextBox)FindName($"IngredientFoodGroupTextBox{i}");

                    if (ingredientNameTextBox != null && ingredientQuantityTextBox != null && ingredientUnitTextBox != null && ingredientCaloriesTextBox != null && ingredientFoodGroupTextBox != null)
                    {
                        if (double.TryParse(ingredientQuantityTextBox.Text, out double quantity) &&
                            int.TryParse(ingredientCaloriesTextBox.Text, out int calories))
                        {
                            currentRecipe.AddIngredient(new Ingredient(
                                ingredientNameTextBox.Text,
                                quantity,
                                ingredientUnitTextBox.Text,
                                calories,
                                ingredientFoodGroupTextBox.Text));
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



