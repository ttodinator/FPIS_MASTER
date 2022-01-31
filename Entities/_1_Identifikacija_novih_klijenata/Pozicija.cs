using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._1_Identifikacija_novih_klijenata
{
    public class Pozicija
    {
        [Key]
        public int IDPoz { get; set; }

        [ForeignKey("Pozicija1")]
        public int? IDPoz1 { get; set; }
        public virtual Pozicija Pozicija1 { get; set; }
        public virtual List<Pozicija> Pozicije { get; set; }
        public string Naziv { get; set; }

        [ForeignKey("OrganizacionaJedinica")]
        public int IDOrgJed { get; set; }
        public OrganizacionaJedinica OrganizacionaJedinica { get; set; }

        public Pozicija()
        {
            Pozicije = new List<Pozicija>();
        }


        public List<Zaposleni> Zaposleni { get; set; }



    }
}
