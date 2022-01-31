using FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu;
using FPIS.Entities._3_Sklapanje_ugovora;
using FPIS.Entities._4_Implementacija_potrebnih_servisa;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._1_Identifikacija_novih_klijenata
{
    public class Zaposleni
    {
        [Key]
        public int IDZap { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }

        [ForeignKey("Pozicija")]
        public int IDZPoz { get; set; }
        public Pozicija Pozicija { get; set; }
        public ZahtevZaPodacima zahtevZaPodacima { get; set; }
        public List<PotencijalniKlijent> PotencijalniKlijentPrima { get; set; }
        public List<PotencijalniKlijent> PotencijalniKlijentSalje { get; set; }
        public List<ZahtevZaProveruKreditneSposobnosti> ZahteviZaProveruKreditneSposobnostiPrima { get; set; }
        public List<ZahtevZaProveruKreditneSposobnosti> ZahteviZaProveruKreditneSposobnostiSalje { get; set; }
        public List<ZahtevZaProveruTehnickihUsluga> ZahtevZaProveruTehnickihUslugaPrima { get; set; }
        public List<ZahtevZaProveruTehnickihUsluga> ZahtevZaProveruTehnickihUslugaSalje { get; set; }
        public List<Proracun> ProracunPrima { get; set; }
        public List<Proracun> ProracunSalje { get; set; }
        public List<Ugovor> UgovorPotpisuje { get; set; }
        public List<Ugovor> UgovorProverava { get; set; }
        public List<ZahtevZaTehnickomPodrskom> ZahteviZaTehnickomPodrskom { get; set; }
        public List<ZahtevZaAktivacijuServisa> ZahteviZaAktivacijuServisa { get; set; }


    }
}
