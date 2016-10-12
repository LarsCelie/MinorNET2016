using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Entities
{
    public class CursusInstantie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Cursus Cursus { get; set; }

        [Required]
        [RegularExpression(@"^[1-3]?[0-9]/1?[0-9]/\d{4}$")]
        public string Startdatum { get; set; }
    }
}
