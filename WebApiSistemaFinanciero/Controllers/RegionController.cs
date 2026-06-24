using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSistemaFinanciero.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiSistemaFinanciero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly DbAlianzaRegionalContext _context;

        public RegionController(DbAlianzaRegionalContext context)
        {
            _context = context;
        }

        [HttpGet("Listar region")]

        public async Task<ActionResult<IEnumerable<TblRegion>>> MtdLista()
        {
            var region = await _context.TblRegions.Select(c => new RegionDTOs
            {
                CodigoRegion = c.CodigoRegion,
                Nombre = c.Nombre
            })
                .ToListAsync();
            return Ok(region);
        }

        [HttpPost("Guardar Region")]

        public async Task<ActionResult> Mtdguardar([FromBody] RegionDTOs region)
        {
            try
            {
                var nuevo = new TblRegion
                {
                    Nombre = region.Nombre
                };

                _context.TblRegions.Add(nuevo);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Region creada con exito", data = region });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guardar", error = ex.Message });
            }
        }

        [HttpPut("Actualizar Region")]

        public async Task<ActionResult> MtdActualizar(int CodigoRegion, [FromBody] RegionDTOs region)
        {
            try
            {
                var nuevo = await _context.TblRegions.FindAsync(CodigoRegion);
                if (nuevo == null)
                    return NotFound(new { mensaje = $"La region {CodigoRegion} no existe" });

                nuevo.Nombre = region.Nombre ?? nuevo.Nombre;

                await _context.SaveChangesAsync();
                return Ok(new { mensaje = "Region actualizada correctamente" });
                

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "error al actualizar", error = ex.Message });                
            }
        }

        [HttpDelete("Eliminar Region")]

        public async Task<ActionResult> MtdEliminar(int CodigoRegion)
        {
            try
            {
                var region = await _context.TblRegions.FindAsync(CodigoRegion);
                if (region == null)
                    return NotFound(new { mensaje = $"La region {CodigoRegion} no existe" });

                _context.TblRegions.Remove(region);
                await _context.SaveChangesAsync();

                return Ok(new { mensaje = $"Cliente {CodigoRegion} eliminado correctamente" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al eliminar", error = ex.Message });                
            }
        }

        [HttpGet("BuscarRegion")]

        public async Task<ActionResult<TblRegion>> MtdBuscar(int CodigoRegion)
        {
            var region = await _context.TblRegions.FindAsync(CodigoRegion);
            if (region == null)
            {
                return NotFound(new { mensaje = $"La region {CodigoRegion} no existe" });
            }
            return (region);
        }
    }
}
