using System.ComponentModel.DataAnnotations;

namespace Models{

    public class Lokacija{

        [Key]
        public int ID { get; set; }

        [Required]
        public string grad { get; set; }

        [Required]
        public string drzava { get; set; }


        [Required]
        public string slika { get; set; }
        
        [Required]
        public string hotel { get; set; }

    }
}