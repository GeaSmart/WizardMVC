using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWizard.Models
{
    public class EmpleadoPersonalViewModel
    {
        [Required (ErrorMessage = "El campo nombres es obligatorio")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo apellidos es obligatorio")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo domicilio es obligatorio")]
        public string Domicilio { get; set; }
    }
}
