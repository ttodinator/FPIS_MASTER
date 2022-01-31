using FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._1_Identifikacija_novih_klijenata
{
    public class Klijent
    {
        [Key]
        public int IDKlijenta { get; set; }
        public string Naziv { get; set; }
        public string PIB { get; set; }
        public string Telefon { get; set; }
        public string WebStrana { get; set; }
        public int GodinaOsnivanja { get; set; }
        [ForeignKey("Delatnost")]
        public int SifraDel { get; set; }
        public Delatnost Delatnost { get; set; }
        [ForeignKey("Broj")]
        public int BrojAdrese { get; set; }
        public Broj Broj { get; set; }
        [ForeignKey("Ulica")]
        public int IDUlice { get; set; }
        public Ulica Ulica { get; set; }
        [ForeignKey("Mesto")]
        public int PostanskiBroj { get; set; }
        public Mesto Mesto { get; set; }
        [ForeignKey("PotencijalniKlijent")]
        public int IDPotKlijenta { get; set; }
        public PotencijalniKlijent PotencijalniKlijent { get; set; }

        public List<ZahtevZaPodacima> ZahteviZaPodacima { get; set; }
        public List<PonudaUredjajaITarifnihPaketa> PonudeUredjajaITarifnihPaketa { get; set; }
        public List<Kredit> Krediti { get; set; }
    }
}
