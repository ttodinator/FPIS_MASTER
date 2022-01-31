using System.ComponentModel.DataAnnotations;

namespace FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu
{
    public class Valuta
    {
        [Key]
        public int? SifraValute { get; set; }
        public string? Naziv { get; set; }
        public List<TekuciRacun>? TekuciRacuni { get; set; }
        public List<VrstaKredita>? VrsteKredita { get; set; }
    }
}
