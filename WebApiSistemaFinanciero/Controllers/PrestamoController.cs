using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSistemaFinanciero.DTOs;

namespace WebApiSistemaFinanciero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly DbAlianzaRegionalContext _context;

        public PrestamoController(DbAlianzaRegionalContext context)
        {
            _context = context;
        }

        [HttpGet("Lista Prestamo")]

        public async Task<ActionResult<IEnumerable<TblPrestamo>>> MtdLista()
        {
            var prestamo = await _context.TblPrestamos.Select(c => new PrestamoDTOs
            {
                CodigoPrestamo = c.CodigoPrestamo,
                CodigoMoneda = c.CodigoMoneda,
                CodigoCliente = c.CodigoCliente,
                TipoPrestamo = c.TipoPrestamo,
                MontoOriginal = c.MontoOriginal,
                SaldoPendiente = c.SaldoPendiente,
                TasaInteres = c.TasaInteres,
                Plazo = c.Plazo,
                FechaInicio = c.FechaInicio,
                Estado = c.Estado
            })

                .ToListAsync();
            return Ok(prestamo);
        }

        [HttpPost("Guardar Prestamo")]

        public async Task<ActionResult> MtdGuardar([FromBody] PrestamoDTOs prestamo)
        {
            try
            {
                var guardar = new TblPrestamo
                {
                    CodigoMoneda = prestamo.CodigoMoneda,
                    CodigoCliente = prestamo.CodigoCliente,
                    TipoPrestamo = prestamo.TipoPrestamo,
                    MontoOriginal = prestamo.MontoOriginal,
                    SaldoPendiente = prestamo.SaldoPendiente,
                    TasaInteres = prestamo.TasaInteres,
                    Plazo = prestamo.Plazo,
                    FechaInicio = prestamo.FechaInicio,
                    Estado = prestamo.Estado
                };

                _context.TblPrestamos.Add(guardar);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Prestamo creado con exito", data = guardar });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guartar", error = ex.Message });                
            }
                       
        }

        [HttpPut("Actualizar Prestamo")]

        public async Task<ActionResult> MtdEditar(int CodigoPrestamo, [FromBody] EditarPrestamoDTOs prestamo)
        {
            try
            {
                var editar = await _context.TblPrestamos.FindAsync(CodigoPrestamo);

                if (editar == null)
                    return NotFound(new { mensaje = $"El prestamo {CodigoPrestamo} no existe" });

                editar.Estado = prestamo.Estado ?? editar.Estado;

                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new { mensaje = $"El prestamo {CodigoPrestamo} se creo con exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al editar", error = ex.Message });
            }
        }

        [HttpDelete]

        public async Task<ActionResult> MtdEliminar(int CodigoPrestamo)
        {
            try
            {
                var eliminar = await _context.TblPrestamos.FindAsync(CodigoPrestamo);
                if (eliminar == null)
                    return NotFound(new { mensaje = $"El prestamo {CodigoPrestamo} no exite" });

                _context.TblPrestamos.Remove(eliminar);
                await _context.SaveChangesAsync();

                return Ok(new { mensaje = $"El prestamo {CodigoPrestamo} se elimino con exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al eliminar", error = ex.Message });
            }
        }

        [HttpGet("Buscar Prestamo")]

        public async Task<ActionResult<TblPrestamo>> MtdBuscar(int CodigoPrestamo)
        {
            var buscar = await _context.TblPrestamos.FindAsync(CodigoPrestamo);
            if(buscar == null)
            {
                return NotFound(new { mensaje = $"El prestamo {CodigoPrestamo} no existe" });
            }

            return (buscar);
                
        }
    }
}
