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
            PersonDataService peopleService = new PersonDataService(contextFactory);

            GenericDataService<Team> teamService = new GenericDataService<Team>(contextFactory);
            GenericDataService<Role> roleService = new GenericDataService<Role>(contextFactory);

            Navigator = new Navigator(peopleService, teamService, roleService);

            // výchozí obrazovka – třeba Home
            Navigator.CurrentViewModel = new HomeViewModel();
        }
    }
}
