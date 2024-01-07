using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_aplicatieWeb.Models
{
    public class Interventie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatoriu de completat")]
        [StringLength(150, MinimumLength = 3)]
        public string Denumire { get; set; } = "";

        [Required(ErrorMessage = "Obligatoriu de completat")]
        [Display(Name = "Specializare")]
        public int SpecializareId { get; set; }

        public Specializare Specializare { get; set; }

        [Column(TypeName = "decimal(7, 2)")]
        public decimal Pret { get; set; }
    }
}
