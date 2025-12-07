using Mach_rocnikova_prace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mach_rocnikova_prace.Models.Person;

namespace Mach_rocnikova_prace.Services
{
    public interface IPersonDataService : IDataService<Person>
    {
        Task<Person?> GetPerson(int id, PersonIncludeOptions includes);
    }
}
