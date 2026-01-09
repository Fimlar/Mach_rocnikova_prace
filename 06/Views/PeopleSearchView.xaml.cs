using Mach_rocnikova_prace.Models;
using Mach_rocnikova_prace.Services;
using Mach_rocnikova_prace.ViewModels;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Mach_rocnikova_prace.Views
{
    /// <summary>
    /// Interakční logika pro PeopleSearch.xaml
    /// </summary>
    public partial class PeopleSearch : UserControl 
    {
        public PeopleSearch()
        {
            InitializeComponent();
        }
        private void PeopleGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction != DataGridEditAction.Commit)
                return;

            var grid = (DataGrid)sender;

            if (DataContext is PeopleSearchViewModel vm &&
                e.Row.Item is Person person)
            {
                // odložíme uložení, dokud WPF nedokončí vlastní commit/binding
                grid.Dispatcher.InvokeAsync(async () =>
                {
                    try
                    {
                        await vm.SavePersonAsync(person);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Chyba při ukládání změn: {e.Message}",
                                        "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }, DispatcherPriority.Background);
            }
        }

        private async void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer soundPlayer = new SoundPlayer(@"..\..\..\Sounds\click.wav");
            soundPlayer.Play();
            TeamRoleAddWindow roleAddWindow = new TeamRoleAddWindow();
            roleAddWindow.Owner = Window.GetWindow(this);
            roleAddWindow.ShowDialog();
            if (DataContext is PeopleSearchViewModel vm)
            {
                try
                {
                    await vm.RefreshLookupsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba při načítání nových dat: {ex.Message}",
                                    "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
