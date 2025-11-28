using Mach_rocnikova_prace.Data;
using Mach_rocnikova_prace.Models;
using Mach_rocnikova_prace.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mach_rocnikova_prace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Test();
            InitializeComponent();
        }
        public void Test()
        {
            /*IDataService<Role> roleService = new GenericDataService<Role>(new RocnikovkaDbContextFactory());
            roleService.Delete(1);*/
            IDataService<Role> roleService = new GenericDataService<Role>(new RocnikovkaDbContextFactory());
            roleService.Create(new Role { Name = "Trenér" });

            /*IDataService<Person> personService = new GenericDataService<Person>(new RocnikovkaDbContextFactory());
            personService.Create(new Person { LastName = "Mach", FirstName = "Filip", Active = true, BirthNumber = 0706304940, DateOfBirth = new DateTime(2007, 6, 30),
            InsuranceCompanyId = 211, InsuranceCompanyName = "ZPMV", Role= });*/
        }
    }
}