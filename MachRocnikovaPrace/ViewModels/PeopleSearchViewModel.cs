using Mach_rocnikova_prace.Commands;
using Mach_rocnikova_prace.Models;
using Mach_rocnikova_prace.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mach_rocnikova_prace.ViewModels
{
    public class PeopleSearchViewModel : ViewModelBase
    {

        private readonly PersonDataService _peopleService;
        private readonly IDataService<Team> _teamService;
        private readonly IDataService<Role> _roleService;

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();
        public ObservableCollection<Team> Teams { get; } = new();
        public ObservableCollection<Role> Roles { get; } = new();

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }

        private PeopleSearchField _selectedSearchField = PeopleSearchField.Id;
        public PeopleSearchField SelectedSearchField
        {
            get => _selectedSearchField;
            set => SetProperty(ref _selectedSearchField, value);
        }

        public ICommand SearchCommand { get; }

        public PeopleSearchViewModel(PersonDataService peopleService, IDataService<Team> teamService, IDataService<Role> roleService)
        {
            _peopleService = peopleService;
            _teamService = teamService;
            _roleService = roleService;

            SearchCommand = new RelayCommand(async _ => await Search());

            _ = LoadPeople();
            _ = LoadTeams();
            _ = LoadRoles();
        }

        private async Task LoadPeople()
        {
            var people = await _peopleService.GetAll();
            People.Clear();
            foreach (var person in people)
                People.Add(person);
        }

        private async Task LoadTeams()
        {
            var teams = await _teamService.GetAll();
            Teams.Clear();
            foreach (var t in teams)
                Teams.Add(t);
        }

        private async Task LoadRoles()
        {
            var roles = await _roleService.GetAll();
            Roles.Clear();
            foreach (var r in roles)
                Roles.Add(r);
        }

        private async Task Search()
        {
            People.Clear();

            switch (SelectedSearchField)
            {
                case PeopleSearchField.Id:
                    if (int.TryParse(SearchText, out int id))
                    {
                        var person = await _peopleService.GetById(id);
                        if (person != null)
                            People.Add(person);
                    }
                    break;

                case PeopleSearchField.LastName:
                    foreach (var p in await _peopleService.GetByLastName(SearchText))
                        People.Add(p);
                    break;

                case PeopleSearchField.Insurance:
                    foreach (var p in await _peopleService.GetByInsuranceId(SearchText))
                        People.Add(p);
                    break;

                case PeopleSearchField.Team:
                    foreach (var p in await _peopleService.GetByTeamId(SearchText))
                        People.Add(p);
                    break;

                case PeopleSearchField.Role:
                    foreach (var p in await _peopleService.GetByRoleId(SearchText))
                        People.Add(p);
                    break;
            }
        }
        public async Task SavePersonAsync(Person person)
        {
            // aktualizuji hodnoty v databázi
            await _peopleService.Update(person.Id, person);

            // načítám zpět upravenou entitu, aby se změny ukázaly v UI
            var refreshed = await _peopleService.GetById(person.Id);

            var index = People.IndexOf(person);
            if (index >= 0 && refreshed is not null)
            {
                People[index] = refreshed;
            }
        }

        public async Task RefreshLookupsAsync()
        {
            await LoadTeams();
            await LoadRoles();
            await LoadPeople();
        }
    }

}
