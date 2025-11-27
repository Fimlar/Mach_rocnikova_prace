using Mach_rocnikova_prace.Commands;
using Mach_rocnikova_prace.MVVMModels;
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
        /// <summary>
        /// proměnná ukládající momentální ViewModel
        /// </summary>
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                // refreshnutí hodnoty
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);

        
    }
}
