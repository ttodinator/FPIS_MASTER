using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._3_Sklapanje_ugovora
{
    public class Ponuda
    {
        [Key]
        public int IDPonude { get; set; }
        public DateTime Datum { get; set; }
        [ForeignKey("Proracun")]
        public int IDProracuna { get; set; }
        public Proracun Proracun { get; set; }
        public DateTime RokPrihvatanja { get; set; }

    }
}
