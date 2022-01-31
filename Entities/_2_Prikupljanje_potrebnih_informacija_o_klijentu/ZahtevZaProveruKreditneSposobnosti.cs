using FPIS.Entities._1_Identifikacija_novih_klijenata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu
{
    public class ZahtevZaProveruKreditneSposobnosti
    {
        [Key]
        public int IDZahteva { get; set; }
        public DateTime Datum { get; set; }
        public string NacinDostave { get; set; }
        [ForeignKey("TekuciRacun")]
        public int IDTR { get; set; }
        public TekuciRacun TekuciRacun { get; set; }
        [ForeignKey("Klijent")]
        public int IDKlijenta { get; set; }
        public Klijent Klijent { get; set; }
        [ForeignKey("ZaposleniSalje")]
        public int IDZaposleniSalje { get; set; }
        public Zaposleni ZaposleniSalje { get; set; }
        [ForeignKey("ZaposleniPrima")]
        public int IDZaposleniPrima { get; set; }
        public Zaposleni ZaposleniPrima { get; set; }
        [ForeignKey("Kredit")]
        public int IDKr { get; set; }
        public Kredit Kredit { get; set; }
        [ForeignKey("VrstaKredita")]
        public int SifraVrsteKr { get; set; }
        public VrstaKredita VrstaKredita { get; set; }
    }
}
