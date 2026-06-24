using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSistemaFinanciero.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiSistemaFinanciero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCuentaController : ControllerBase
    {
        private readonly DbAlianzaRegionalContext _context;

        public TipoCuentaController(DbAlianzaRegionalContext context)
        {
            _context = context;
        }

        [HttpGet("Listar Tipo Cuenta")]

        public async Task<ActionResult<IEnumerable<TblTiposCuentum>>> MtdListar()
        {
            var lista = await _context.TblTiposCuenta.Select(c => new TipoDuentaDTOs
            {
                CodigoTipoCuenta = c.CodigoTipoCuenta,
                Nombre = c.Nombre,
                Estado = c.Estado
            })
                .ToListAsync();
                return Ok(lista);
        }

        [HttpPost("Guardar Tipo Cuenta")]

        public async Task<ActionResult> MtdGuardar([FromBody] TipoDuentaDTOs TipoCuenta)
        {
            try
            {
                var nueva = new TblTiposCuentum
                {
                    Nombre = TipoCuenta.Nombre,
                    Estado = TipoCuenta.Estado
                };

                _context.TblTiposCuenta.Add(nueva);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Tipo de cuenta guardado con exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guardar el tipo de cuenta", error = ex.Message });
            }
        }

        [HttpPut("Actualizar Tipo Cuenta")]

        public async Task<ActionResult> MtdActualizar(int CodigoTipoCuenta, [FromBody] TipoDuentaDTOs cuenta)
        {
            try
            {
                var actualizar = await _context.TblTiposCuenta.FindAsync(CodigoTipoCuenta);
                if (actualizar == null)
                    return NotFound(new { mensaje = $"El tipo de cuenta {CodigoTipoCuenta} no existe" });

                actualizar.Nombre = cuenta.Nombre ?? actualizar.Nombre;
                actualizar.Estado = cuenta.Estado ?? actualizar.Estado;

                await _context.SaveChangesAsync();

                return Ok(new { mensaje = "Cuenta actulizada con exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al actualizar", error = ex.Message });
            }
        }

        [HttpDelete("Eliminar Tipo Cuenta")]

        public async Task<ActionResult> MtdEliminar(int CodigoTipoCuenta)
        {
            try
            {
                var tipocuenta = await _context.TblTiposCuenta.FindAsync(CodigoTipoCuenta);
                if (tipocuenta == null)
                    return NotFound(new { mensaje = $"El tipo de cuenta {CodigoTipoCuenta} no existe" });
                _context.TblTiposCuenta.Remove(tipocuenta);
                await _context.SaveChangesAsync();

                return Ok(new { mensaje = $"El tipo de cuenta {CodigoTipoCuenta} se a eliminado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al eliminar", error = ex.Message });
            }
        }

        [HttpGet("Buscar Tipo Cuenta")]

        public async Task<ActionResult<TblTiposCuentum>> MtdBuscar(int CodigoTipoCuenta)
        {
            var tipocuenta = await _context.TblTiposCuenta.FindAsync(CodigoTipoCuenta);
            if(tipocuenta == null)
            {
                return NotFound($"El tipo de cuenta {CodigoTipoCuenta} no existe");
            }
            return (tipocuenta);
        }
    }
}
