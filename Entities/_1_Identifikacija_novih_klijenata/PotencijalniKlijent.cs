using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._1_Identifikacija_novih_klijenata
{
    public class PotencijalniKlijent
    {
        [Key]
        public int IDPotKlijenta { get; set; }
        public DateTime Datum { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        [ForeignKey("ZaposleniSalje")]
        public int ZaposleniSaljeId { get; set; }

        public Zaposleni ZaposleniSalje { get; set; }

        [ForeignKey("ZaposleniPrima")]
        public int ZaposleniPrimaId { get; set; }

        public Zaposleni ZaposleniPrima { get; set; }

        public string Napomena { get; set; }

    }
}
