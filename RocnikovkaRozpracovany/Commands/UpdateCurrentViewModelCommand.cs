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
        private readonly IDataService<Person> _peopleService;

        public UpdateCurrentViewModelCommand(INavigator navigator,
                                             IDataService<Person> peopleService)
        {
            _navigator = navigator;
            _peopleService = peopleService;
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

                    case ViewType.People:
                        _navigator.CurrentViewModel = new PeopleViewModel(_peopleService);
                        break;
                }
            }
        }
    }
}