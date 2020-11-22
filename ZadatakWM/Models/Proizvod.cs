using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZadatakWM.Models
{
    public class Proizvod
    {
        public int ProizvodId { get; set; }

        [Required(ErrorMessage = "Unesite naziv")]
        [StringLength(50, ErrorMessage = "Maksimalno 50 karaktera")]
        public string Naziv { get; set; }

        [StringLength(150, ErrorMessage = "Maksimalno 120 karaktera")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Unesite kategoriju")]
        [StringLength(50, ErrorMessage = "Maksimalno 50 karaktera")]
        public string Kategorija { get; set; }

        [Required(ErrorMessage = "Unesite proizvodjaca")]
        [StringLength(50, ErrorMessage = "Maksimalno 50 karaktera")]
        public string Proizvodjac { get; set; }

        [Required(ErrorMessage = "Unesite dobavljaca")]
        [StringLength(50, ErrorMessage = "Maksimalno 50 karaktera")]
        public string Dobavljac { get; set; }

        [Required(ErrorMessage = "Unesite cenu")]
        public double Cena { get; set; }
    }
}