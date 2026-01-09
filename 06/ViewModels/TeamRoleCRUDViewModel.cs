using Mach_rocnikova_prace.Commands;
using Mach_rocnikova_prace.Controls;
using Mach_rocnikova_prace.Exceptions;
using Mach_rocnikova_prace.Models;
using Mach_rocnikova_prace.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Mach_rocnikova_prace.ViewModels
{
    public class TeamRoleAddViewModel : ViewModelBase
    {
        public CustomTextBox RoleNameBox { get; set; }
        public CustomTextBox TeamNameBox { get; set; }
        private readonly RoleDataService _roleDataService;
        private readonly TeamDataService _teamDataService;
        public TeamRoleAddViewModel(RoleDataService roleDataService, TeamDataService teamDataService)
        {
            _roleDataService = roleDataService;
            _teamDataService = teamDataService;

            AddRoleCommand = new RelayCommand(async param => await AddRole(param));
            AddTeamCommand = new RelayCommand(async param => await AddTeam(param));
            DeleteRoleCommand = new RelayCommand(async _ => await DeleteRole(), _ => SelectedRole != null);
            DeleteTeamCommand = new RelayCommand(async _ => await DeleteTeam(), _ => SelectedTeam != null);

            _ = LoadRoles();
            _ = LoadTeams();
        }
        public ICommand AddRoleCommand { get; }
        public ICommand AddTeamCommand { get; }

        public ICommand DeleteRoleCommand { get; }
        public ICommand DeleteTeamCommand { get; }

        // pro mazání rolí
        public ObservableCollection<Role> Roles { get; } = new();

        private Role? _selectedRole;
        public Role? SelectedRole
        {
            get => _selectedRole;
            set => SetProperty(ref _selectedRole, value);
        }

        // pro mazání týmů
        public ObservableCollection<Team> Teams { get; } = new();

        private Team? _selectedTeam;
        public Team? SelectedTeam
        {
            get => _selectedTeam;
            set => SetProperty(ref _selectedTeam, value);
        }

        
        // nahrání rolí, abych je mohl zobrazit v ComboBoxu
        private async Task LoadRoles()
        {
            Roles.Clear();
            var roles = await _roleDataService.GetAll();
            foreach (var role in roles)
                Roles.Add(role);
        }

        // nahrání týmů, abych je mohl zobrazit v ComboBoxu
        private async Task LoadTeams()
        {
            Teams.Clear();
            var teams = await _teamDataService.GetAll();
            foreach (var team in teams)
                Teams.Add(team);
        }



        private async Task AddRole(object? param)
        {
            var role = new Role { Name = param?.ToString() };
            await _roleDataService.Create(role);
            // vyčistit text
            RoleNameBox.Text = "Role uložena";
            // zrušit fokus
            Keyboard.ClearFocus();
            // aby se zobrazily změny v Comboboxu
            await LoadRoles();
        }

        private async Task AddTeam(object? param)
        {
            var team = new Team { Name = param?.ToString() };
            await _teamDataService.Create(team);
            TeamNameBox.Text = "Tým uložen";
            Keyboard.ClearFocus();
            // aby se zobrazily změny v Comboboxu
            await LoadTeams();
        }

        // na mazání role
        private async Task DeleteRole()
        {
            if (SelectedRole == null)
                return;

            try
            {
                await _roleDataService.Delete(SelectedRole.Id);

                Roles.Remove(SelectedRole);
                SelectedRole = null;
                Keyboard.ClearFocus();
                // aby se zobrazily změny v Comboboxu
                await LoadRoles();
            }
            catch (EntityInUseException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Nelze smazat",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                // fallback – kdyby se stalo něco neočekávaného
                MessageBox.Show(
                    $"Neočekávaná chyba: {ex.Message}",
                    "Chyba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        // na mazání týmu
        private async Task DeleteTeam()
        {
            if (SelectedTeam == null)
                return;

            try
            {
                await _teamDataService.Delete(SelectedTeam.Id);

                Teams.Remove(SelectedTeam);
                SelectedTeam = null;
                Keyboard.ClearFocus();
                // aby se zobrazily změny v Comboboxu
                await LoadTeams();
            }
            catch (EntityInUseException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Nelze smazat",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                // fallback – kdyby se stalo něco neočekávaného
                MessageBox.Show(
                    $"Neočekávaná chyba: {ex.Message}",
                    "Chyba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

    }
}
