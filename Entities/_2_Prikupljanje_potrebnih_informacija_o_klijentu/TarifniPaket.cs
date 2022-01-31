using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu
{
    public class TarifniPaket
    {
        [Key]
        public int IDTF { get; set; }
        public string Naziv { get; set; }
        public int BrojMinuta { get; set; }
        public int BrojPoruka { get; set; }
        public int BrojMB { get; set; }
        [ForeignKey("Vrsta")]
        public int IDVrste { get; set; }
        public VrstaPaketa VrstaPaketa { get; set; }
        public List<StavkaPonude> StavkePonude { get; set; }
    }
}
