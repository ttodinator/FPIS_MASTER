
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu
{
    public class Uredjaj
    {
        [Key]
        public int IDUredjaja { get; set; }
        public string Naziv { get; set; }
        public string Model { get; set; }
        public string Boja { get; set; }
        public double Cena { get; set; }

        [ForeignKey("Proizvodjac")]
        public int IDProizvodjaca { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
        public List<StavkaPonude> StavkePonude { get; set; }
    }
}
