using FPIS.Entities._1_Identifikacija_novih_klijenata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu
{
    public class Kredit
    {
        [Key]
        public int IDKr { get; set; }
        public double OdobreniIznos { get; set; }
        public double IskorisceniIznos { get; set; }
        public DateTime DatumPocetkaKoriscenja { get; set; }
        public DateTime DatumPocetkaOtplate { get; set; }
        public DateTime DatumKrajaOtplate { get; set; }
        public int PeriodOtplate { get; set; }
        public double OstatakDuga { get; set; }
        public string Status { get; set; }
        [ForeignKey("VrstaKredita")]
        public int SifraVrsteKr { get; set; }
        public VrstaKredita VrstaKredita { get; set; }
        [ForeignKey("Klijent")]
        public int IDKlijenta { get; set; }
        public Klijent Klijent { get; set; }
        public List<ZahtevZaProveruKreditneSposobnosti> ZahteviZaProveruKreditneSposobnosti { get; set; }
    }
}
