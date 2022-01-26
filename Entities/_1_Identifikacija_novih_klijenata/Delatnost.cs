using System.ComponentModel.DataAnnotations;

namespace FPIS.Entities._1_Identifikacija_novih_klijenata
{
    public class Delatnost
    {
        [Key]
        public int SifraDel { get; set; }
        public string Naziv { get; set; }
    }
}
