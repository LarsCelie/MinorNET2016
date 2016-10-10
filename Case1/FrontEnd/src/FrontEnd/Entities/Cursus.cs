using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Entities
{
    public class Cursus
    {
        [Key,StringLength(10)]
        public string Code { get; set; }

        [Required, StringLength(300)]
        public string Titel { get; set; }

        [Required, Range(1,5)]
        public int Duur { get; set; }

    }
}
