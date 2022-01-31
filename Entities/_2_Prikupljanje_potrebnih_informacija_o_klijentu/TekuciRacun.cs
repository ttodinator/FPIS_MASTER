using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu
{
    public class TekuciRacun
    {
        [Key]
        public int IDTR { get; set; }
        [ForeignKey("Valuta")]
        public int SifraValute { get; set; }
        public Valuta Valuta { get; set; }
        public DateTime DatumOtvaranja { get; set; }
        public double ProsecanMesecniPriliv { get; set; }
        public double ProsecanMesecniOdliv { get; set; }
        public string Status { get; set; }
        public string NazivNosiocaRacuna { get; set; }
        public List<ZahtevZaProveruKreditneSposobnosti> ZahteviZaProveruKreditneSposobnosti { get; set; }

    }
}
