using Mach_rocnikova_prace.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Mach_rocnikova_prace
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }

}
