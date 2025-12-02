using Mach_rocnikova_prace.Models;
using Mach_rocnikova_prace.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mach_rocnikova_prace.ViewModels
{
    public class PeopleViewModel : ViewModelBase
    {
        private readonly IDataService<Person> _peopleService;

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        public PeopleViewModel(IDataService<Person> peopleService)
        {
            _peopleService = peopleService;

            // načítáme lidi
            _ = LoadPeople();
        }

        /// <summary>
        /// Task pro načtění všech lidí do ObservableCollection
        /// </summary>
        /// <returns></returns>
        private async Task LoadPeople()
        {
            // získáme data z db
            var people = await _peopleService.GetAll();

            People.Clear();

            // uložíme získaná data do kolekce
            foreach (var person in people)
            {
                People.Add(person);
            }
        }
    }
}
