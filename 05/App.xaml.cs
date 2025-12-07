using Mach_rocnikova_prace.Data;
using Mach_rocnikova_prace.Models;
using Mach_rocnikova_prace.Services;
using Mach_rocnikova_prace.ViewModels;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace Mach_rocnikova_prace
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // nastavení kultury na českou, kvůli formátu dat
            var culture = new CultureInfo("cs-CZ");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(culture.IetfLanguageTag)));

            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();
            

            base.OnStartup(e);
        }
    }

}
