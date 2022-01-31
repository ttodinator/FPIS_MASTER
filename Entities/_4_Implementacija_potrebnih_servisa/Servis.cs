using System.ComponentModel.DataAnnotations;

namespace FPIS.Entities._4_Implementacija_potrebnih_servisa
{
    public class Servis
    {
        [Key]
        public int IDServisa { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public List<StavkaZahtevaTP> StavkeZahtevaTP { get; set; }
    }
}
