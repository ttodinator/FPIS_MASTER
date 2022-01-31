using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._4_Implementacija_potrebnih_servisa
{
    public class PotvrdaORealizacijiPodrske
    {
        [Key]
        public int IDPotvrde { get; set; }
        public DateTime Datum { get; set; }
        public bool Uradjeno { get; set; }
        [ForeignKey("StavkaZahtevaTP")]
        public int Rbr { get; set; }
        public StavkaZahtevaTP StavkaZahtevaTP { get; set; }
        [ForeignKey("ZaTehnickomPodrskom")]
        public int IDZahtevaTP { get; set; }
        public ZahtevZaTehnickomPodrskom ZaTehnickomPodrskom { get; set; }
    }
}
