using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._4_Implementacija_potrebnih_servisa
{
    public class StavkaZahtevaTP
    {
        [Key]
        public int Rbr { get; set; }
        [ForeignKey("ZahtevZaTehnickomPodrskom")]
        public int IDZahtevaTP { get; set; }
        public ZahtevZaTehnickomPodrskom ZahtevZaTehnickomPodrskom { get; set; }
        public string Opis { get; set; }
        public List<PotvrdaORealizacijiPodrske> PotvrdeORealizacijiPodrske { get; set; }
    }
}
