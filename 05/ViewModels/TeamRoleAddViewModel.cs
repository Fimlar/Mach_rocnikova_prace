using Mach_rocnikova_prace.Commands;
using Mach_rocnikova_prace.Controls;
using Mach_rocnikova_prace.Models;
using Mach_rocnikova_prace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mach_rocnikova_prace.ViewModels
{
    public class TeamRoleAddViewModel : ViewModelBase
    {
        public CustomTextBox RoleNameBox { get; set; }
        public CustomTextBox TeamNameBox { get; set; }
        private readonly IDataService<Role> _roleDataService;
        private readonly IDataService<Team> _teamDataService;
        public TeamRoleAddViewModel(IDataService<Role> roleDataService, IDataService<Team> teamDataService)
        {
            _roleDataService = roleDataService;
            _teamDataService = teamDataService;

            AddRoleCommand = new RelayCommand(async param => await AddRole(param));
            AddTeamCommand = new RelayCommand(async param => await AddTeam(param));
        }
        public ICommand AddRoleCommand { get; }
        public ICommand AddTeamCommand { get; }

        private async Task AddRole(object? param)
        {
            var role = new Role { Name = param?.ToString() };
            await _roleDataService.Create(role);
            // vyčistit text
            RoleNameBox.Text = "Role uložena";
            // zrušit fokus
            Keyboard.ClearFocus();
        }

        private async Task AddTeam(object? param)
        {
            var team = new Team { Name = param?.ToString() };
            await _teamDataService.Create(team);
            TeamNameBox.Text = "Tým uložen";
            Keyboard.ClearFocus();
        }
    }
}
