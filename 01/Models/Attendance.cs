using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocnikovka_first.Models
{
    public class Attendance
    {
        [Key]
        public int id { get; set; }

        public int training_id { get; set; }

        public int person_id { get; set; }

        public int status { get; set; }         // 0: přítomen, 1: omluven, 2: neomluven
    }
}
