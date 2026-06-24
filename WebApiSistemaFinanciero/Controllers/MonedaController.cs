using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSistemaFinanciero.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiSistemaFinanciero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private readonly DbAlianzaRegionalContext _context;
        
        public MonedaController(DbAlianzaRegionalContext context)
        {
            _context = context;
        }

        [HttpGet("Lista Moneda")]

        public async Task<ActionResult<IEnumerable<TblMoneda>>> MtdListar()
        {
            var moneda = await _context.TblMonedas.Select(c => new MonedaDTOs
            {
                CodigoMoneda = c.CodigoMoneda,
                Nombre = c.Nombre,
                Simbolo = c.Simbolo,
                Estado = c.Estado
            })
                .ToListAsync();
            return Ok(moneda);
        }

        [HttpPost("Guardar Moneda")]

        public async Task<ActionResult> MtdGuardar([FromBody] MonedaDTOs moneda)
        {
            try
            {
                var nueva = new TblMoneda
                {
                    Nombre = moneda.Nombre,
                    Simbolo = moneda.Simbolo,
                    Estado = moneda.Estado
                };
                _context.TblMonedas.Add(nueva);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Moneda Guardada", data = nueva });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guardar", error = ex.Message });                
            }
        }

        [HttpPut("Actualizar Moneda")]

        public async Task<ActionResult> MtdActualizar(int CodigoMoneda, [FromBody] MonedaDTOs moneda)
        {
            try
            {
                var nueva = await _context.TblMonedas.FindAsync(CodigoMoneda);
                if (nueva == null)

                    return NotFound(new { mensaje = $"La moneda {CodigoMoneda} no existe" });
                
                    nueva.Nombre = moneda.Nombre    ?? nueva.Nombre;
                    nueva.Simbolo = moneda.Simbolo ?? nueva.Simbolo;
                    nueva.Estado = moneda.Estado    ?? nueva.Estado;

                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Moneda Actualizada" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guarar", error = ex.Message });                
            }
        }

        [HttpDelete("Eliminar Moneda")]
        public async Task<ActionResult> MtdEliminar(int CodigoMoneda)
        {
            try
            {
                var moneda = await _context.TblMonedas.FindAsync(CodigoMoneda);
                if (moneda == null)
                    return NotFound(new { mensaje = $"La moneda {CodigoMoneda} no existe" });
                _context.TblMonedas.Remove(moneda);

                await _context.SaveChangesAsync();

                return Ok(new { mensaje = $"Moneda {CodigoMoneda} Eliminada" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al eliminar", error = ex.Message });                
            }
        }

        [HttpGet("Buscar Moneda")]

        public async Task<ActionResult<TblMoneda>> MtdBuscar(int CodigoMoneda)
        {
            var moneda = await _context.TblMonedas.FindAsync(CodigoMoneda);
            if (moneda == null)
            {
                return NotFound(new { mensaje = $"La moneda {CodigoMoneda} no existe" });
            }

            return (moneda);
        }
    }
}
