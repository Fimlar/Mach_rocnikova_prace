using Rocnikovka_first.Data;
using Rocnikovka_first.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Rocnikovka_first.ViewModels
{
    /// <summary>
    /// ViewModel pro hlavní okno aplikace.
    /// Řídí seznam členů, aktuálně vybraného člena a CRUD operace.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ICrudService _crudService;

        /// <summary>
        /// Kolekce všech členů – vázána na DataGrid ve View.
        /// ObservableCollection zajišťuje, že změny se automaticky projeví v UI.
        /// </summary>
        public ObservableCollection<Member> Members { get; } = new();

        private Member? _selectedMember;

        /// <summary>
        /// Aktuálně vybraný člen (řádek v DataGridu / upravovaný v TextBoxech).
        /// </summary>
        public Member? SelectedMember
        {
            get => _selectedMember;
            set
            {
                _selectedMember = value;
                OnPropertyChanged();
                // Po změně výběru mohou změnit stav tlačítek (Save/Delete)
                SaveCommand_Relay?.RaiseCanExecuteChanged();
                DeleteCommand_Relay?.RaiseCanExecuteChanged();
            }
        }
        // ICommand vlastnosti pro binding v XAML:

        public ICommand LoadCommand { get; }
        public ICommand NewCommand { get; }
        public ICommand SaveCommand => SaveCommand_Relay;
        public ICommand DeleteCommand => DeleteCommand_Relay;

        // Interně držíme RelayCommand, abychom mohli volat RaiseCanExecuteChanged
        internal RelayCommand SaveCommand_Relay { get; }
        internal RelayCommand DeleteCommand_Relay { get; }

        /// <summary>
        /// Konstruktor ViewModelu. Vytvoří CRUD službu a nastaví příkazy.
        /// </summary>
        public MainWindowViewModel()
        {
            // V jednoduché aplikaci si kontext a službu vytvoříme ručně.
            // Pro větší projekty je lepší DI (HostBuilder, ServiceProvider, ...).
            var context = new RocnikovkaContext();
            _crudService = new CrudService(context);

            LoadCommand = new RelayCommand(async _ => await LoadAsync());
            NewCommand = new RelayCommand(_ => CreateNew());

            SaveCommand_Relay = new RelayCommand(
                async _ => await SaveAsync(),
                _ => SelectedMember != null // povoleno jen pokud je něco vybráno
            );

            DeleteCommand_Relay = new RelayCommand(
                async _ => await DeleteAsync(),
                _ => SelectedMember != null && SelectedMember.Member_ID != 0
            );

            // Můžeš klidně automaticky načíst data při startu:
            _ = LoadAsync();
        }

        /// <summary>
        /// READ – načte všechny členy z databáze a doplní kolekci Members.
        /// </summary>
        public async Task LoadAsync()
        {
            var data = await _crudService.ReadAllAsync<Member>();

            Members.Clear();
            foreach (var m in data)
            {
                Members.Add(m);
            }

            // Pokud je prázdno, žádný člen není vybrán
            if (Members.Count == 0)
            {
                SelectedMember = null;
            }
        }

        /// <summary>
        /// CREATE – připraví nového člena v kolekci a označí ho jako vybraného.
        /// Uživatel pak vyplní detaily vpravo.
        /// </summary>
        public void CreateNew()
        {
            var newMember = new Member
            {
                // Zde můžeš nastavit výchozí hodnoty (Active = true apod.)
                Active = true
            };

            Members.Add(newMember);
            SelectedMember = newMember;
        }

        /// <summary>
        /// CREATE / UPDATE – uloží aktuálně vybraného člena do DB.
        /// Rozhoduje podle hodnoty primárního klíče Member_ID.
        /// </summary>
        public async Task SaveAsync()
        {
            if (SelectedMember == null)
                return;

            // Nový záznam – Member_ID == 0 (předpoklad identity sloupce)
            if (SelectedMember.Member_ID == 0)
            {
                await _crudService.CreateAsync(SelectedMember);
            }
            else
            {
                await _crudService.UpdateAsync(SelectedMember);
            }

            // Po uložení znovu načteme z databáze,
            // aby se např. doplnilo vygenerované ID.
            await LoadAsync();
        }

        /// <summary>
        /// DELETE – smaže aktuálně vybraného člena.
        /// </summary>
        public async Task DeleteAsync()
        {
            if (SelectedMember == null)
                return;

            // Pro jistotu – nové objekty bez ID nechceme mazat z DB.
            if (SelectedMember.Member_ID == 0)
            {
                Members.Remove(SelectedMember);
                SelectedMember = null;
                return;
            }

            await _crudService.DeleteAsync(SelectedMember);

            Members.Remove(SelectedMember);
            SelectedMember = null;
        }

        // ===== INotifyPropertyChanged implementace =====

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Oznámí UI, že se změnila hodnota vlastnosti.
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
