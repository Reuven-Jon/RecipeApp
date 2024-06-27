using NUnit.Framework;
using RecipeAppPart1;

namespace RecipeAppTests
{
    [TestFixture]
    public class RecipeTests
    {
        [Test]
        public void CalculateTotalCalories_ShouldReturnCorrectTotal()
        {
            // Arrange
            var recipe = new Recipe();
            recipe.AddIngredient(new Ingredient("Chicken", 1, "kg", 500, "Meat"));
            recipe.AddIngredient(new Ingredient("Rice", 1, "cup", 200, "Grain"));
            recipe.AddIngredient(new Ingredient("Carrot", 1, "piece", 30, "Vegetable"));

            // Act
            var totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(730, totalCalories);
        }
    }
}

