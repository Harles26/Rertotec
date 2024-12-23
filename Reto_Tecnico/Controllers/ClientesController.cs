using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reto_Tecnico.Context;
using Reto_Tecnico.Models;

namespace Reto_Tecnico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetCliente()
        {
            var clientes = await _context.Cliente.ToListAsync();

            // Crear una lista de clientes 
            var resultado = clientes.Select(cliente =>
            {
                // Calcular la edad 
                int edad = DateTime.Now.Year - cliente.FechaNacimiento.Year;

                // Verificar la edad
                if (DateTime.Now.DayOfYear < cliente.FechaNacimiento.DayOfYear)
                {
                    edad--;
                }

                return new
                {
                    cliente.Id,
                    cliente.Nombre,
                    cliente.Apellidos,
                    FechaNacimiento = cliente.FechaNacimiento.ToString("yyyy-MM-dd"),
                    Edad = edad
                };
            }).ToList();

            return resultado;
        }



        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetClientes(int id)
        {
            var clientes = await _context.Cliente.FindAsync(id);

            if (clientes == null)
            {
                return NotFound();
            }

            // Calcular la edad
            int edad = DateTime.Now.Year - clientes.FechaNacimiento.Year;
            if (DateTime.Now.DayOfYear < clientes.FechaNacimiento.DayOfYear)
            {
                edad--;  
            }

            var resultado = new
            {
                clientes.Id,
                clientes.Nombre,
                clientes.Apellidos,
               
                FechaNacimiento = clientes.FechaNacimiento.ToString("yyyy-MM-dd"),
                Edad = edad
            };

            return resultado;
        }
        [HttpGet("top3")]
        public async Task<ActionResult<IEnumerable<object>>> GetTop3Clientes()
        {
            var clientes = await _context.Cliente.ToListAsync();

            var resultado = clientes
                .Select(cliente =>
                {
                    // Calcular la edad 
                    int edad = DateTime.Now.Year - cliente.FechaNacimiento.Year;

                    // Verificar edad
                    if (DateTime.Now.DayOfYear < cliente.FechaNacimiento.DayOfYear)
                    {
                        edad--;
                    }

                    return new
                    {
                        cliente.Id,
                        cliente.Nombre,
                        cliente.Apellidos,
                        FechaNacimiento = cliente.FechaNacimiento.ToString("yyyy-MM-dd"),
                        Edad = edad
                    };
                })
                .OrderByDescending(c => c.Edad)  
                .Take(3) 
                .ToList();

            return resultado;
        }


        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes(int id, Clientes clientes)
        {
            if (id != clientes.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {
            clientes.FechaNacimiento = clientes.FechaNacimiento.Date;

            _context.Cliente.Add(clientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientes", new { id = clientes.Id }, clientes);
        }


        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            var clientes = await _context.Cliente.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(clientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientesExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}
