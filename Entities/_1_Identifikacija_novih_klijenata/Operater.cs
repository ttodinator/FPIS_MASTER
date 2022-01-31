using System.ComponentModel.DataAnnotations;

namespace FPIS.Entities._1_Identifikacija_novih_klijenata
{
    public class Operater
    {
        [Key]
        public int IDOperatera { get; set; }
        public string Naziv { get; set; }
    }
}
