using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._2_Prikupljanje_potrebnih_informacija_o_klijentu
{
    public class VrstaPaketa
    {
        [Key]
        public int IDVrste { get; set; }
        public string Naziv { get; set; }
        public List<TarifniPaket> TarifniPaketi { get; set; }
    }
}
