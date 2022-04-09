using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoalSystems.Models
{
    public class Incidencia
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        [ForeignKey("IdEmpleado")]
        public Empleado Empleado { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}