using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._3_Sklapanje_ugovora
{
    public class StavkaPonudeSklapanjeUgovora
    {
        [Key]
        public int Rbr { get; set; }
        [ForeignKey("Ponuda")]
        public int IDPonude { get; set; }
        public Ponuda Ponuda { get; set; }
        [ForeignKey("StavkaProracuna")]
        public int RbrStavkaProracuna { get; set; }
        public StavkaProracuna StavkaProracuna { get; set; }
        [ForeignKey("Proracun")]
        public int IDProracuna { get; set; }
        public Proracun Proracun { get; set; }
    }
}
