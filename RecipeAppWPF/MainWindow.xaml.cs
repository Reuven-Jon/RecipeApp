using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RecipeAppPart1;
using Microsoft.VisualBasic;
using System.Windows.Media;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;
        private Recipe currentRecipe;
        private int ingredientCount = 0;
        private WelcomeWindow welcomeWindow;

        public MainWindow()
        {
            InitializeComponent();
            recipes = Recipe.GetAllRecipes();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();
        }

        private void CloseWelcomeWindow()
        {
            if (welcomeWindow != null)
            {
                welcomeWindow.Close();
                welcomeWindow = null;
            }
        }

        private void AddRecipe_Checked(object sender, RoutedEventArgs e)
        {
            CloseWelcomeWindow();
            currentRecipe = new Recipe();
            RecipeDetailsPanel.Visibility = Visibility.Visible;
            RecipeListBox.Visibility = Visibility.Collapsed;
            IngredientsPanel.Children.Clear();
            ingredientCount = 0;
            AddIngredientInputFields();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            AddIngredientToRecipe();
            ClearIngredientInputFields();
            AddIngredientInputFields();
        }

        private void AddIngredientInputFields()
        {
            ingredientCount++;

            var ingredientNameLabel = new TextBlock
            {
                Text = $"Enter name of Ingredient {ingredientCount}",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Blue
            };
            var ingredientNameTextBox = new TextBox { Width = 300, Height = 30, Margin = new Thickness(10), Name = $"IngredientNameTextBox{ingredientCount}" };
            IngredientsPanel.Children.Add(ingredientNameLabel);
            IngredientsPanel.Children.Add(ingredientNameTextBox);

            var ingredientQuantityLabel = new TextBlock
            {
                Text = $"Enter Quantity of Ingredient {ingredientCount}",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Blue
            };
            var ingredientQuantityTextBox = new TextBox { Width = 300, Height = 30, Margin = new Thickness(10), Name = $"IngredientQuantityTextBox{ingredientCount}" };
            IngredientsPanel.Children.Add(ingredientQuantityLabel);
            IngredientsPanel.Children.Add(ingredientQuantityTextBox);

            var ingredientUnitLabel = new TextBlock
            {
                Text = $"Enter Unit of Ingredient {ingredientCount}",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Blue
            };
            var ingredientUnitTextBox = new TextBox { Width = 300, Height = 30, Margin = new Thickness(10), Name = $"IngredientUnitTextBox{ingredientCount}" };
            IngredientsPanel.Children.Add(ingredientUnitLabel);
            IngredientsPanel.Children.Add(ingredientUnitTextBox);

            var ingredientCaloriesLabel = new TextBlock
            {
                Text = $"Enter Calories of Ingredient {ingredientCount}",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Blue
            };
            var ingredientCaloriesTextBox = new TextBox { Width = 300, Height = 30, Margin = new Thickness(10), Name = $"IngredientCaloriesTextBox{ingredientCount}" };
            IngredientsPanel.Children.Add(ingredientCaloriesLabel);
            IngredientsPanel.Children.Add(ingredientCaloriesTextBox);

            var ingredientFoodGroupLabel = new TextBlock
            {
                Text = $"Enter Food Group of Ingredient {ingredientCount}",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Blue
            };
            var ingredientFoodGroupTextBox = new TextBox { Width = 300, Height = 30, Margin = new Thickness(10), Name = $"IngredientFoodGroupTextBox{ingredientCount}" };
            IngredientsPanel.Children.Add(ingredientFoodGroupLabel);
            IngredientsPanel.Children.Add(ingredientFoodGroupTextBox);
        }

        private void AddIngredientToRecipe()
        {
            if (currentRecipe != null)
            {
                var ingredientNameTextBox = (TextBox)FindName($"IngredientNameTextBox{ingredientCount}");
                var ingredientQuantityTextBox = (TextBox)FindName($"IngredientQuantityTextBox{ingredientCount}");
                var ingredientUnitTextBox = (TextBox)FindName($"IngredientUnitTextBox{ingredientCount}");
                var ingredientCaloriesTextBox = (TextBox)FindName($"IngredientCaloriesTextBox{ingredientCount}");
                var ingredientFoodGroupTextBox = (TextBox)FindName($"IngredientFoodGroupTextBox{ingredientCount}");

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
                        MessageBox.Show($"Invalid quantity or calories for Ingredient {ingredientCount}. Please enter valid numbers.");
                    }
                }
            }
        }

        private void ClearIngredientInputFields()
        {
            IngredientsPanel.Children.Clear();
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            CloseWelcomeWindow();

            if (currentRecipe != null && !string.IsNullOrEmpty(RecipeNameTextBox.Text))
            {
                currentRecipe.Name = RecipeNameTextBox.Text;

                for (int i = 1; i <= ingredientCount; i++)
                {
                    AddIngredientToRecipe();
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
            CloseWelcomeWindow();
            RecipeListBox.Visibility = Visibility.Visible;
            RecipeDetailsPanel.Visibility = Visibility.Collapsed;
            RecipeListBox.ItemsSource = recipes.Select(r => r.Name).ToList();
        }

        private void DisplayCalories_Checked(object sender, RoutedEventArgs e)
        {
            CloseWelcomeWindow();
            RecipeListBox.Visibility = Visibility.Visible;
            RecipeDetailsPanel.Visibility = Visibility.Collapsed;
            RecipeListBox.ItemsSource = recipes.Select(r => r.Name).ToList();
        }

        private void DisplayFoodGroups_Checked(object sender, RoutedEventArgs e)
        {
            CloseWelcomeWindow();
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
            CloseWelcomeWindow();
            Application.Current.Shutdown();
        }
    }
}



