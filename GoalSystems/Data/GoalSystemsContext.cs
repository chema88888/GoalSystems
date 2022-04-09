using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoalSystems.Models;

namespace GoalSystems.Data
{
    public class GoalSystemsContext : DbContext
    {
        public GoalSystemsContext (DbContextOptions<GoalSystemsContext> options)
            : base(options)
        {
        }
                
        public DbSet<GoalSystems.Models.Incidencia> Incidencia { get; set; }

        public DbSet<GoalSystems.Models.Empleado> Empleado { get; set; }

        public DbSet<GoalSystems.Models.Empresa> Empresa { get; set; }

        public DbSet<GoalSystems.Models.Tarea> Tarea { get; set; }
    }
}
