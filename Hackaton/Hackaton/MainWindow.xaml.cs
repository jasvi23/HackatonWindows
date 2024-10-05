using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Hackaton
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Background = new SolidColorBrush(Colors.LightBlue);
            this.wellcome.Background = new SolidColorBrush(Colors.LightCoral);
            this.difficulty.Background = new SolidColorBrush(Colors.LightCoral);
            this.easy.Background = new SolidColorBrush(Colors.LightCoral);
            this.medium.Background = new SolidColorBrush(Colors.LightCoral);
            this.hard.Background = new SolidColorBrush(Colors.LightCoral);

            // Establecer la opacidad inicial de los elementos del submenú
            this.easy.Opacity = 0;
            this.medium.Opacity = 0;
            this.hard.Opacity = 0;
        }

        private void Wellcome_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el submenú de dificultad
            var difficultyMenu = (MenuItem)this.difficulty;

            // Crear la animación para cada submenú
            var storyboard = new Storyboard();
            double delay = 0.0;

            foreach (MenuItem item in difficultyMenu.Items)
            {
                var fadeInAnimation = new DoubleAnimation
                {
                    From = 0.0,
                    To = 1.0,
                    Duration = TimeSpan.FromSeconds(0.5),
                    BeginTime = TimeSpan.FromSeconds(delay),
                };

                Storyboard.SetTarget(fadeInAnimation, item);
                Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(OpacityProperty));
                storyboard.Children.Add(fadeInAnimation);

                delay += 0.2; // Incrementar el delay para el efecto escalonado
            }

            storyboard.Begin();
        }
    }
}
