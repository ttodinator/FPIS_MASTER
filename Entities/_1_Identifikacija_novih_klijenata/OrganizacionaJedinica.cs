using System.ComponentModel.DataAnnotations;

namespace FPIS.Entities._1_Identifikacija_novih_klijenata
{
    public class OrganizacionaJedinica
    {
        [Key]
        public int IDOrgJed { get; set; }
        public string Naziv { get; set; }
        public List<Pozicija> Pozicije { get; set; }
    }
}
