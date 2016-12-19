using System.ComponentModel.DataAnnotations;

namespace Minor.Dag16.DatabaseTestDriven
{

    public class Boog
    {
        public Categorie Categorie { get; set; }
        public int Id { get; set; }
        public int Lengte { get; set; }
        public string Merk { get; set; }
        public decimal Prijs { get; set; }
        public bool Rechtshandig { get; set; }
    }

}