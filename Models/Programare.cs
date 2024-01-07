using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace Proiect_aplicatieWeb.Models
{
    public class Programare
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatoriu de completat")]
        [Display(Name = "Pacient")]
        public int PacientId { get; set; }

        public Pacient Pacient { get; set; }

        [Display(Name = "Medic")]
        public int MedicId {  get; set; }

        public Medic Medic { get; set; }

        [Display(Name = "Interventie")]
        public int InterventieId { get; set; }

        public Interventie Interventie { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [DataType(DataType.Time)]
        public DateTime Ora { get; set; }
    }
}
