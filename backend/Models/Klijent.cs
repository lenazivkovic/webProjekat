using System.ComponentModel.DataAnnotations;

namespace Models{

    public class Klijent{

        [Key]
        public int ID { get; set; }

        [Required]
        public string imeKlijenta { get; set; }

        [Required]
        public string prezimeKlijenta { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$")]
        public string JMBG { get; set; }

        [Required]
        public string grad { get; set; }

        [Required]
        public string adresa { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$")]
        public string kontaktTelefon { get; set; }
    }
}