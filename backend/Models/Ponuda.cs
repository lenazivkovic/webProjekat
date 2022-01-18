using System;
using System.ComponentModel.DataAnnotations;

namespace Models{

    public class Ponuda{


        [Key]
        public int ID { get; set; }

        [Required]
        public Lokacija lokacija { get; set; }

        [Required]
        public int cena { get; set; }

        [Required]
        public DateTime datum { get; set; }

        [Required]
        public Agencija agencija {get;set;}
    }
}