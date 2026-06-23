using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSistemaFinanciero.DTOs;

namespace WebApiSistemaFinanciero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly DbAlianzaRegionalContext _context;

        public CuentasController(DbAlianzaRegionalContext context)
        {
            _context = context;
        }

        [HttpGet("Listar Cuenta")]
        public async Task<ActionResult<IEnumerable<TblCuenta>>> ListarCuenta()
        {
            var cuenta = await _context.TblCuentas.Select(c => new CuentasDTOs
            {
                CodigoCuenta = c.CodigoCuenta,
                CodigoCliente = c.CodigoCliente,
                CodigoMoneda = c.CodigoMoneda,
                CodigoTipoCuenta = c.CodigoTipoCuenta,
                NumeroCuenta = c.NumeroCuenta,
                Saldo = c.Saldo,
                FechaCreacion = c.FechaCreacion,
                Estado = c.Estado
            })
                .ToListAsync();
            return Ok(cuenta);
        }

        [HttpPost("Guardar Cuenta")]
        public async Task<ActionResult> GuardarCuenta([FromBody] CrearCuentaDTOs cuenta)
        {
            try
            {
                var NuevaCuenta = new TblCuenta
                {
                    CodigoCliente = cuenta.CodigoCliente,
                    CodigoMoneda = cuenta.CodigoMoneda,
                    CodigoTipoCuenta = cuenta.CodigoTipoCuenta,
                    NumeroCuenta = cuenta.NumeroCuenta,
                    Saldo = cuenta.Saldo,
                    FechaCreacion = cuenta.FechaCreacion,
                    Estado = cuenta.Estado
                };

                _context.TblCuentas.Add(NuevaCuenta);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Cuenta guardada correctamente", data = NuevaCuenta });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error l guardar la cuenta", error = ex.Message });
            }
                      

        }

        [HttpPut("Actualizar Cuenta")]
        public async Task<ActionResult> ActualizarCuenta(int CodigoCuenta, [FromBody] ActualizarCuentaDTOs cuenta)
        {
            try
            {
                var cuentaA = await _context.TblCuentas.FindAsync(CodigoCuenta);
                if (cuentaA == null)
                    return NotFound(new { mensaje = $"La cuenta {CodigoCuenta} no existe" });
                    
                    cuentaA.CodigoMoneda        = cuenta.CodigoMoneda       ?? cuentaA.CodigoMoneda;
                    cuentaA.CodigoTipoCuenta    = cuenta.CodigoTipoCuenta   ?? cuentaA.CodigoTipoCuenta;
                    cuentaA.NumeroCuenta        = cuenta.NumeroCuenta       ?? cuentaA.NumeroCuenta;
                    cuentaA.Saldo               = cuenta.Saldo              ?? cuentaA.Saldo;
                    cuentaA.Estado              = cuenta.Estado             ?? cuentaA.Estado;

                await _context.SaveChangesAsync();
                return Ok(new { mensaje = "Cuenta actualizada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al actualizar", error = ex.Message });
                
            }
        }

        [HttpDelete("Eliminar Cuenta")]
        public async Task<ActionResult> EliminarCuenta(int CodigoCuenta)
        {
            try
            {
                var cuenta = await _context.TblCuentas.FindAsync(CodigoCuenta);
                if (cuenta == null)
                return NotFound(new { mensaje = $"El la cuenta {CodigoCuenta} no existe" });

                _context.TblCuentas.Remove(cuenta);
                await _context.SaveChangesAsync();
                return Ok(new {mensaje =$"Cuenta {CodigoCuenta} eliminada con exito"});
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al eliminar", error = ex.Message });                
            }
        }

        [HttpGet("Buscar Cuenta")]
        public async Task<ActionResult<TblCuenta>> BuscarCuenta(int CodigoCuenta)
        {
            var cuenta = await _context.TblCuentas.FindAsync(CodigoCuenta);
            if (cuenta == null)
            {
                return NotFound(new { mensaje = $"La cuenta {CodigoCuenta} no existe" });
            }
            return (cuenta);
         }
        
    }
}
