using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu
{
    public class VrstaKredita
    {
        [Key]
        public int? SifraVrsteKr { get; set; }
        public string? Naziv { get; set; }
        [ForeignKey("Valuta")]
        public int? SifraValute { get; set; }
        public Valuta? Valuta { get; set; }
        public List<Kredit>? Krediti { get; set; }
        public List<ZahtevZaProveruKreditneSposobnosti>? ZahteviZaProveruKreditneSposobnosti { get; set; }
    }
}
