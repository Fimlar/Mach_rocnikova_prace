using Mach_rocnikova_prace.Data;
using Mach_rocnikova_prace.Models;
using Mach_rocnikova_prace.Services;
using Mach_rocnikova_prace.State.Navigators;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mach_rocnikova_prace.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; }

        public MainViewModel()
        {
            var contextFactory = new RocnikovkaDbContextFactory();
            IDataService<Person> peopleService = new GenericDataService<Person>(contextFactory);

            Navigator = new Navigator(peopleService);

            // výchozí obrazovka – třeba Home
            Navigator.CurrentViewModel = new HomeViewModel();
        }
    }
}
