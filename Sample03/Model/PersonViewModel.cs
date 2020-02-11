using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample03.Model
{
    public class PersonViewModel
    {
        public string account { get; set; }

        public Nullable<System.DateTime> birth { get; set; }

        public string position { get; set; }

        public List<string> skill { get; set; }
    }
}