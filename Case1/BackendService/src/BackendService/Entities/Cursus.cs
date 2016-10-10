using System.ComponentModel.DataAnnotations;

namespace BackendService.Entities
{
    public class Cursus
    {
        [Key, StringLength(10)]
        public string Code { get; set; }

        [Required, StringLength(300)]
        public string Titel { get; set; }

        [Required, Range(1, 5)]
        public int Duur { get; set; }
    }
}