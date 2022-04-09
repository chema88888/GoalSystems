using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace GoalSystems.Models
{
    public class IncidenciasListado
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}