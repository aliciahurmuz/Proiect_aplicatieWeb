using System.ComponentModel.DataAnnotations;

namespace Proiect_aplicatieWeb.Models
{
    public class Pacient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatoriu de completat")]
        [StringLength(150, MinimumLength = 3)]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Obligatoriu de completat")]
        [StringLength(150, MinimumLength = 3)]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Obligatoriu de completat")]
        public string Telefon { get; set; }
    }
}
