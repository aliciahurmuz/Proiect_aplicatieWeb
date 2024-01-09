using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_aplicatieWeb.Models
{
    public class Medic
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatoriu de completat")]
        [StringLength(150, MinimumLength = 3)]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Obligatoriu de completat")]
        [StringLength(150, MinimumLength = 3)]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Obligatoriu de completat")]
        public int SpecializareId { get; set; }

        public Specializare Specializare { get; set; }

        public string Telefon { get; set; }
    }
}
