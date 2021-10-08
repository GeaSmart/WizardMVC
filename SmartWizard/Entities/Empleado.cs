using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWizard.Entities
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string Nombres { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string Apellidos { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Domicilio { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Departamento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public decimal Salario { get; set; }
    }
}
