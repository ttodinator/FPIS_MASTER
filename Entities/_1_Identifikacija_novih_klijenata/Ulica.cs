﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPIS.Entities._1_Identifikacija_novih_klijenata
{
    public class Ulica
    {
        [Key]
        public int IDUlice { get; set; }
        public string Naziv { get; set; }

        [ForeignKey("Mesto")]
        public int PostanskiBroj { get; set; }
        public Mesto Mesto { get; set; }

        public List<Broj> Brojevi { get; set; }
        public List<Klijent> Klijenti { get; set; }

    }
}
