using System.ComponentModel.DataAnnotations;

namespace Proiect_aplicatieWeb.Models
{
    public class Specializare
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatoriu de completat")]
        [StringLength(150, MinimumLength = 3)]
        public string Denumire { get; set; }
    }
}
