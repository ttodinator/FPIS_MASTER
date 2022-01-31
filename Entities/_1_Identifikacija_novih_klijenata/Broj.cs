using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._1_Identifikacija_novih_klijenata
{
    public class Broj
    {
        [Key]
        public int BrojAdrese { get; set; }

        [ForeignKey("Ulica")]
        public int IDUlice { get; set; }
        public Ulica Ulica { get; set; }

        [ForeignKey("Mesto")]
        public int PostanskiBroj { get; set; }
        public Mesto Mesto { get; set; }

        public List<Klijent> Klijenti { get; set; }
    }
}
