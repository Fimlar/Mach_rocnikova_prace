using Mach_rocnikova_prace.Commands;
using Mach_rocnikova_prace.Models;
using Mach_rocnikova_prace.MVVMModels;
using Mach_rocnikova_prace.Services;
using Mach_rocnikova_prace.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mach_rocnikova_prace.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand { get; }

        public Navigator(PersonDataService peopleService,
                         TeamDataService teamService,
                         RoleDataService roleService)
        {
            UpdateCurrentViewModelCommand =
                new UpdateCurrentViewModelCommand(this, peopleService, teamService, roleService);
        }
    }
}
