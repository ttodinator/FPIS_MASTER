using FPIS.Entities._1_Identifikacija_novih_klijenata;
using FPIS.Entities._4_Implementacija_potrebnih_servisa;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._3_Sklapanje_ugovora
{
    public class Ugovor
    {
        [Key]
        public int IDUgovora { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string Napomena { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        [ForeignKey("ZaposleniPotpisuje")]
        public int IDZaposleniPotpisuje { get; set; }
        public Zaposleni ZaposleniPotpisuje { get; set; }
        [ForeignKey("ZaposleniProverava")]
        public int IDZaposleniProverava { get; set; }
        public Zaposleni ZaposleniProverava { get; set; }
        [ForeignKey("Ponuda")]
        public int IDPonude { get; set; }
        public Ponuda Ponuda { get; set; }
        public List<ZahtevZaTehnickomPodrskom> ZahteviZaTehnickomPodrskom { get; set; }
        public List<ZahtevZaAktivacijuServisa> ZahteviZaAktivacijuServisa { get; set; }
    }
}