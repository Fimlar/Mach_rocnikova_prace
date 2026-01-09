using Mach_rocnikova_prace.Models;
using Mach_rocnikova_prace.Services;
using Mach_rocnikova_prace.State.Navigators;
using Mach_rocnikova_prace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mach_rocnikova_prace.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly PersonDataService _peopleService;
        private readonly TeamDataService _teamService;
        private readonly RoleDataService _roleService;

        public UpdateCurrentViewModelCommand(INavigator navigator,
                                             PersonDataService peopleService,
                                             TeamDataService teamService,
                                             RoleDataService roleService)
        {
            _navigator = navigator;
            _peopleService = peopleService;
            _teamService = teamService;
            _roleService = roleService;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is ViewType viewType)
            {
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;

                    case ViewType.SearchPeople:
                        _navigator.CurrentViewModel = new PeopleSearchViewModel(_peopleService, _teamService, _roleService);
                        break;

                    case ViewType.TeamRoleAdd:
                        _navigator.CurrentViewModel = new TeamRoleAddViewModel(_roleService, _teamService);
                        break;

                    case ViewType.People:
                        _navigator.CurrentViewModel = new PeopleViewModel(_peopleService);
                        break;
                }
            }
        }
    }
}