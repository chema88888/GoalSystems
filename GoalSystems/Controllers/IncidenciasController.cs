using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoalSystems.Data;
using GoalSystems.Models;

namespace GoalSystems.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IncidenciasController : ControllerBase
    {
        private readonly GoalSystemsContext _context;

        public IncidenciasController(GoalSystemsContext context)
        {
            _context = context;
        }

        // GET: api/Incidencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incidencia>>> GetIncidencias()
        {           
            //Muestra todas las incidencias con los datos del empleado y la empresa

            return await _context.Incidencia.Include(a => a.Empleado.Empresa).ToListAsync();
        }

        [HttpGet("{idEmpleado}")]
        public async Task<ActionResult<IEnumerable<IncidenciasListado>>> GetIncidenciasByEmpleado(int idEmpleado)
        {
            List<Incidencia> lista = await _context.Incidencia.Include(a => a.Empleado.Empresa).Where(a => a.IdEmpleado == idEmpleado).ToListAsync();

            List<IncidenciasListado> listaIncidencias = new List<IncidenciasListado>();

            foreach (var item in lista)
            {
                IncidenciasListado incidencia = new IncidenciasListado()
                {
                    Id = item.Id,
                    NombreEmpleado = item.Empleado.Nombre + " " + item.Empleado.Apellidos,
                    Descripcion = item.Descripcion,
                    FechaAlta = item.FechaAlta                    
                };

                listaIncidencias.Add(incidencia);
            }

            return listaIncidencias;
        }                

        [HttpPost]
        public async Task<ActionResult<Incidencia>> AddIncidencia(Incidencia incidencia)
        {
            _context.Incidencia.Add(incidencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncidencia", new { Id = incidencia.Id }, incidencia);
        }

        // DELETE: api/Incidencias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Incidencia>> DeleteIncidencia(int id)
        {
            var incidencia = await _context.Incidencia.FindAsync(id);
            if (incidencia == null)
            {
                return NotFound();
            }

            _context.Incidencia.Remove(incidencia);
            await _context.SaveChangesAsync();

            return incidencia;
        }        
    }
}