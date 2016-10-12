using System.ComponentModel.DataAnnotations;

namespace BackendService.Entities
{
    public class Cursus
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(10)]
        public string Code { get; set; }

        [Required, MaxLength(300)]
        public string Titel { get; set; }

        [Required, Range(1, 5)]
        public int Duur { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Cursus))
            {
                return false;
            }
            Cursus other = obj as Cursus;
            return other.Titel == Titel && other.Code == Code && other.Duur == Duur;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode() ^ Titel.GetHashCode();
        }
    }
}