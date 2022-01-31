using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu
{
    public class StavkaPonude
    {
        [Key]
        public int Rbr { get; set; }
        [ForeignKey("PonudaUredjajaITarifnihPaketa")]
        public int IDPonude { get; set; }
        public PonudaUredjajaITarifnihPaketa PonudaUredjajaITarifnihPaketa { get; set; }
        [ForeignKey("Uredja")]
        public int IDUredjaja { get; set; }
        public Uredjaj Uredjaj { get; set; }
        [ForeignKey("TarifniPaket")]
        public int IDTF { get; set; }
        public TarifniPaket TarifniPaket { get; set; }



    }
}
