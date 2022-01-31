using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._4_Implementacija_potrebnih_servisa
{
    public class StavkaZahtevaAS
    {
        [Key]
        public int Rbr { get; set; }

        [ForeignKey("ZahtevZaAktivacijuServisa")]
        public int IDZahtevaAS { get; set; }
        public ZahtevZaAktivacijuServisa ZahtevZaAktivacijuServisa { get; set; }
        [ForeignKey("Servis")]
        public int IDServisa { get; set; }
        public Servis Servis { get; set; }
        public DateTime RokIsporuke { get; set; }


    }
}
