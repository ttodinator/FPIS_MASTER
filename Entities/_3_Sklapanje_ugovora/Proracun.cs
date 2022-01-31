using FPIS.Entities._1_Identifikacija_novih_klijenata;
using FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._3_Sklapanje_ugovora
{
    public class Proracun
    {
        [Key]
        public int IDProracuna { get; set; }
        public DateTime Datum { get; set; }
        public string Napomena { get; set; }
        public double Popust { get; set; }
        public double CenaSaPopustom { get; set; }
        [ForeignKey("ZaposleniSalje")]
        public int IDZaposleniSalje { get; set; }
        public Zaposleni ZaposleniSalje { get; set; }
        [ForeignKey("ZaposleniPrima")]
        public int IDZaposleniPrima { get; set; }
        public Zaposleni ZaposleniPrima { get; set; }
        [ForeignKey("PonudaUređajaITarifnihPaketa")]
        public int IDPonude { get; set; }
        public PonudaUredjajaITarifnihPaketa PonudaUredjajaITarifnihPaketa { get; set; }
        public List<StavkaPonudeSklapanjeUgovora> StavkePonudeSklapanjeUgovora { get; set; }
    }
}
