using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalSystems.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}