using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWizard.Models
{
    public class EmpleadoLaboralViewModel
    {
        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "El salario es obligatorio")]
        public Decimal Salario { get; set; }
    }
}
