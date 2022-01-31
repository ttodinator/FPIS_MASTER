using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._1_Identifikacija_novih_klijenata
{
    public class ZahtevZaPodacima
    {
        [Key]
        public int IDZahteva { get; set; }
        public DateTime Datum { get; set; }
        public int BrZaposlenih { get; set; }
        public string BrSIMKartica { get; set; }
        [ForeignKey("Zaposleni")]
        public int IDZap { get; set; }
        public Zaposleni Zaposleni { get; set; }
        [ForeignKey("Klijent")]
        public int? IDKlijenta { get; set; }
        public Klijent Klijent { get; set; }
        [ForeignKey("Operater")]
        public int IDOperatera { get; set; }
        public Operater Operater { get; set; }
    }
}
