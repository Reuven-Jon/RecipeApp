using System.Windows;
using System.Windows.Media.Animation;

namespace RecipeApp
{
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var storyboard = (Storyboard)FindResource("FadeInStoryboard");
            storyboard.Begin();
        }
    }
}



