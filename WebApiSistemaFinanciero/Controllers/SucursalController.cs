using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSistemaFinanciero.DTOs;

namespace WebApiSistemaFinanciero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly DbAlianzaRegionalContext _context;

        public SucursalController(DbAlianzaRegionalContext context)
        {
            _context = context;
        }

        [HttpGet("Listar Sucursales")]

           public async Task<ActionResult<IEnumerable<TblSucursale>>> MtdListarSucursal()
        {
                var sucursal = await _context.TblSucursales.Select(c => new SucursalDTOs
                {
                    CodigoSucursal = c.CodigoSucursal,
                    CodigoMunicipio = c.CodigoMunicipio,
                    Nombre = c.Nombre,
                    Direccion = c.Direccion,
                    Telefono = c.Telefono,
                    Estado = c.Estado
                })
                    .ToListAsync();
                return Ok(sucursal);
           }

        [HttpPost("Guardar Sucursal")]

        public async Task<ActionResult> MtdGuardarSucursal([FromBody] CrearSucursalDTOs sucursal)
        {
            try
            {
                var Nueva = new TblSucursale
                {
                    CodigoMunicipio = sucursal.CodigoMunicipio,
                    Nombre = sucursal.Nombre,
                    Direccion = sucursal.Direccion,
                    Telefono = sucursal.Telefono,
                    Estado = sucursal.Estado
                };
                _context.TblSucursales.Add(Nueva);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Sucursal creada exitosamente", data = Nueva });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guardar sucursal", error = ex.Message });

            }
        }

        [HttpPut("Actualizar Cliente")]

        public async Task<ActionResult> MtdActualizarSucursal(int CodigoSucursal, [FromBody] ActualizarSucursalDTOs sucursal)
        {
            try
            {
                var Actualizar = await _context.TblSucursales.FindAsync(CodigoSucursal);
                if (Actualizar == null)

                    return NotFound(new { mensaje = $"La sucursal {CodigoSucursal} no existe" });

                Actualizar.CodigoMunicipio = sucursal.CodigoMunicipio ?? Actualizar.CodigoMunicipio;
                Actualizar.Nombre          = sucursal.Nombre          ?? Actualizar.Nombre;
                Actualizar.Direccion       = sucursal.Direccion       ?? Actualizar.Direccion;
                Actualizar.Telefono        = sucursal.Telefono        ?? Actualizar.Telefono;
                Actualizar.Estado          = sucursal.Estado          ?? Actualizar.Estado;

                await _context.SaveChangesAsync();
                return Ok(new { mensaje = "Sucursal actualizada exitosamente" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al actualizar", error = ex.Message });

            }
        }

        [HttpDelete("Eliminar Sucursal")]

        public async Task<ActionResult> MtdEliminarSucursal(int CodigoSucursal)
        {
            try
            {
                var sucursal = await _context.TblSucursales.FindAsync(CodigoSucursal);
                if (sucursal == null)
                    return NotFound(new { mensaje = $"La sucursal {CodigoSucursal} no existe" });
                _context.TblSucursales.Remove(sucursal);
                    await _context.SaveChangesAsync();
                return Ok(new { mensaje = $"Susursal {CodigoSucursal} eliminada con exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al eliminar", erro = ex.Message });                
            }
        }

        [HttpGet("Buscar Sucursal")]

        public async Task<ActionResult<TblSucursale>> MtdBuscarSucursal(int CodigoSucursal)
        {
            var sucursal = await _context.TblSucursales.FindAsync(CodigoSucursal);
            if (sucursal == null)
            {
                return NotFound(new { mensaje = $"Sucursal {CodigoSucursal} no encontrada" });
            }
            return (sucursal);
        }
    }
}
