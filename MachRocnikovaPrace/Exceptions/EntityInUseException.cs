using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mach_rocnikova_prace.Exceptions
{
    public class EntityInUseException : Exception
    {
        public string EntityName { get; }
        public int EntityId { get; }

        public EntityInUseException(string entityName, int entityId)
            : base($"{entityName} je přiřazen/a alespoň jednomu člověku a nelze tudíž smazat.")
        {
            EntityName = entityName;
            EntityId = entityId;
        }
    }
}
