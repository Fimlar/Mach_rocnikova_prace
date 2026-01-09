using Mach_rocnikova_prace.Data;
using Mach_rocnikova_prace.Models;
using Mach_rocnikova_prace.Services;
using Mach_rocnikova_prace.ViewModels;
using System.Windows;

namespace Mach_rocnikova_prace.Views
{
    /// <summary>
    /// Interakční logika pro TeamRoleAddWindow.xaml
    /// </summary>
    public partial class TeamRoleAddWindow : Window
    {
        public TeamRoleAddWindow()
        {
            InitializeComponent();

            var factory = new RocnikovkaDbContextFactory();
            var roleService = new RoleDataService(factory);
            var teamService = new TeamDataService(factory);

            var vm = new TeamRoleAddViewModel(roleService, teamService);

            // ← Dáme ViewModelu reference na textboxy
            vm.RoleNameBox = RoleNameBox;
            vm.TeamNameBox = TeamNameBox;

            DataContext = vm;
        }
    }
}
