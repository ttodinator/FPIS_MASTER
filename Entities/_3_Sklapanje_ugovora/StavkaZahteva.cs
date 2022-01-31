using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._3_Sklapanje_ugovora
{
    public class StavkaZahteva
    {
        [Key]
        public int Rbr { get; set; }
        [ForeignKey("ZahtevZaProveruTehnickihUsluga")]
        public int IDZahteva { get; set; }
        public ZahtevZaProveruTehnickihUsluga ZahtevZaProveruTehnickihUsluga { get; set; }
        public string Opis { get; set; }
    }
}