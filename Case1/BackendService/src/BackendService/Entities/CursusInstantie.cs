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
        public DateTime Startdatum { get; set; }


    }
}
