using FPIS.Entities._1_Identifikacija_novih_klijenata;
using FPIS.Entities._3_Sklapanje_ugovora;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._4_Implementacija_potrebnih_servisa
{
    public class ZahtevZaAktivacijuServisa
    {
        [Key]
        public int IDZahtevaAS { get; set; }
        public DateTime Datum { get; set; }
        public bool Odobreno { get; set; }
        [ForeignKey("Zaposleni")]
        public int IDZap { get; set; }
        public Zaposleni Zaposleni { get; set; }
        [ForeignKey("Ugovor")]
        public int IDUgovora { get; set; }
        public Ugovor Ugovor { get; set; }
        public List<StavkaZahtevaAS> StavkeZahtevaAs { get; set; }
    }
}
