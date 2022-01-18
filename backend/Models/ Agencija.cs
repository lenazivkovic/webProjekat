using System.ComponentModel.DataAnnotations;

namespace Models{

    public class Agencija{

        [Key]
        public int ID { get; set; }

        [Required]
        public string imeAgencije { get; set; }

        [Required]
        public string adresa { get; set; }

        [Required]
        public string email {get;set;}

        [Required]
        [RegularExpression("^[0-9]*$")]
        public string kontaktTelefon { get; set; }
    }
}