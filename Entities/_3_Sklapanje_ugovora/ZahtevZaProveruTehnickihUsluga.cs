using FPIS.Entities._1_Identifikacija_novih_klijenata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._3_Sklapanje_ugovora
{
    public class ZahtevZaProveruTehnickihUsluga
    {
        [Key]
        public int IDZahteva { get; set; }
        public DateTime Datum { get; set; }
        public bool Odobreno { get; set; }
        [ForeignKey("ZaposleniSalje")]
        public int IDZaposleniSalje { get; set; }
        public Zaposleni ZaposleniSalje { get; set; }
        [ForeignKey("ZaposleniPrima")]
        public int IDZaposleniPrima { get; set; }
        public Zaposleni ZaposleniPrima { get; set; }
        public List<StavkaZahteva> StavkeZahteva { get; set; }
    }
}
