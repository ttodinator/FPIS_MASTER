using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu
{
    public class Proizvodjac
    {
        [Key]
        public int IDProizvodjaca { get; set; }
        public string Naziv { get; set; }
        public List<Uredjaj> Uredjaji { get; set; }
    }
}
