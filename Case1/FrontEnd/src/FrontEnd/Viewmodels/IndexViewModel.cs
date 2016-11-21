using FrontEnd.Agents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Viewmodels
{
    public class IndexViewModel
    {
        public IList<CursusInstantie> Cursussen { get; set; }

        public int Weeknummer { get; set; }
        public int Year { get; set; }

    }
}
