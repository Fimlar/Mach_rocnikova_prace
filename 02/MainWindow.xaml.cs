using System.Windows;
using Rocnikovka_first.ViewModels;

namespace Rocnikovka_first
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Konstruktor hlavního okna.
        /// Nastaví DataContext na MainWindowViewModel (MVVM pattern).
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Pokud necháš <Window.DataContext> v XAML, následující řádek není nutný.
            // Pokud ho odstraníš, tenhle řádek zajistí přiřazení ViewModelu.
            if (DataContext == null)
            {
                DataContext = new MainWindowViewModel();
            }
        }
    }
}
