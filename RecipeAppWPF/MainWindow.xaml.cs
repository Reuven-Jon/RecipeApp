using System.Collections.Generic;
using System.Windows;
using RecipeAppPart1; // Ensure this namespace correctly references where your Recipe and Ingredient classes are defined.

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateFoodGroups(); // Populate the ComboBox with food groups
            DisplayIngredients(); // Optionally, load ingredients when the window loads
            DisplayRecipes(); // Optionally, load recipes when the window loads
        }

        private void DisplayIngredients_Click(object sender, RoutedEventArgs e)
        {
            DisplayIngredients();
        }

        private void DisplayIngredients()
        {
            var ingredients = Ingredient.GetAllIngredients();
            RecipesListView.ItemsSource = ingredients;
        }

        private void DisplayRecipes()
        {
            var recipes = Recipe.GetAllRecipes();
            RecipesListView.ItemsSource = recipes;
        }

        // Event handler for a button to refresh or display recipes
        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            DisplayRecipes();
        }

        // Event handler for filtering recipes based on criteria
        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = IngredientFilter.Text;
            string foodGroup = FoodGroupFilter.SelectedItem as string; // Assuming this is correctly populated
            int maxCalories = int.TryParse(CaloriesFilter.Text, out int calories) ? calories : 0;

            var filteredRecipes = Recipe.FilterRecipes(ingredientName, foodGroup, maxCalories);
            RecipesListView.ItemsSource = filteredRecipes;
        }

        // Method to populate the FoodGroupFilter ComboBox with food groups
        private void PopulateFoodGroups()
        {
            // Example food groups - adjust based on your application needs
            var foodGroups = new List<string> { "Grain", "Vegetable", "Fruit", "Protein", "Dairy" };
            FoodGroupFilter.ItemsSource = foodGroups;
        }
    }
}





