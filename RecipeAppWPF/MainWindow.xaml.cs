using System.Windows;

namespace RecipeApp
{
    using System.Windows;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Optionally, load ingredients when the window loads
            DisplayIngredients();
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
    }


    // Event handler for displaying recipes
    private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Logic to display recipes
            // Similar to above, you might set the ItemsSource of a ListView to a collection of recipes
 
                // Assuming you have a method to get all recipes
                var recipes = GetAllRecipes();
                RecipesListView.ItemsSource = recipes;

        }
    }
}

