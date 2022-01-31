using FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._3_Sklapanje_ugovora
{
    public class StavkaProracuna
    {
        [Key]
        public int Rbr { get; set; }
        [ForeignKey("Proracun")]
        public int IDProracuna { get; set; }
        public Proracun Proracun { get; set; }
        [ForeignKey("Uredjaj")]
        public int IDUredjaja { get; set; }
        public Uredjaj Uredjaj { get; set; }
        [ForeignKey("TarifniPaket")]
        public int IDTF { get; set; }
        public TarifniPaket TarifniPaket { get; set; }
        [NotMapped]
        public List<StavkaPonudeSklapanjeUgovora> StavkePonudeSklapanjeUgovora { get; set; }


    }
}
