using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    internal class Preference
    {
        public string person { get; set; }
        public bool interval { get; set; }
        public bool now { get; set; }
        public bool remind { get; set; }
        public int remindBefore { get; set; }
    }
}
