using FPIS.Entities._1_Identifikacija_novih_klijenata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu
{
    public class PonudaUredjajaITarifnihPaketa
    {
        [Key]
        public int IDPounde { get; set; }
        public DateTime Datum { get; set; }
        [ForeignKey("Zaposleni")]
        public int IDZap { get; set; }
        public Zaposleni Zaposleni { get; set; }
        [ForeignKey("Klijent")]
        public int IDKlijenta { get; set; }
        public Klijent Klijent { get; set; }
        public List<StavkaPonude> StavkePonude { get; set; }
    }
}
