using System.ComponentModel.DataAnnotations;

namespace Models{

    public class Rezervacija{

        [Key]
        public int ID { get; set; }

        [Required]
        public int brojOsoba {get;set;}

        [Required]
        public int brojDana {get;set;}

        [Required]
        public Klijent klijent { get; set; }

        [Required]
        public Ponuda ponuda { get; set; }
    }
}