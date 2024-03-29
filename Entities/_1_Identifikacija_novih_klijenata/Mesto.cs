﻿using System.ComponentModel.DataAnnotations;

namespace FPIS.Entities._1_Identifikacija_novih_klijenata
{
    public class Mesto
    {
        [Key]
        public int PostanskiBroj { get; set; }
        public string Naziv { get; set; }
        public List<Ulica> Ulice { get; set; }
        public List<Broj> Brojevi { get; set; }
    }
}
