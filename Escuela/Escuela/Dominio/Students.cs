using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Dominio
{
    public class Students
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "DATO REQUERIDO")]
        public string LastName { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "DATO REQUERIDO")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "DATO REQUERIDO")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime EnrollmentsDate { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }

    
}
