using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSistemaFinanciero.DTOs;

namespace WebApiSistemaFinanciero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly DbAlianzaRegionalContext _context;

        public MunicipioController(DbAlianzaRegionalContext context)
        {
            _context = context;
        }

        [HttpGet("Lista Municipio")]

        public async Task<ActionResult<IEnumerable<TblMunicipio>>> MtdListarMunucipio()
        {
            var municipio = await _context.TblMunicipios.Select(c => new ListarMunicipioDTOs
            {
                CodigoMunicipio = c.CodigoMunicipio,
                CodigoDepartamento = c.CodigoDepartamento,
                Nombre = c.Nombre
            })
            .ToListAsync();
            return Ok(municipio);
        }

        [HttpPost("Guardar Municipio")]

        public async Task<ActionResult> MtdGuardarMunicipio([FromBody] CrearMunicipo municipio)
        {
            try
            {
                var nuevo = new TblMunicipio
                {
                    CodigoDepartamento = municipio.CodigoDepartamento,
                    Nombre = municipio.Nombre
                };
                _context.TblMunicipios.Add(nuevo);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Municipio guardado con exito", data = nuevo });
            
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guardar  sucursal", error = ex.Message });
            }
        }

        [HttpPut("Actualizar Municipio")]

        public async Task<ActionResult> MtdActualizarMunicipio(int CodigoMunicipio, [FromBody] CrearMunicipo municipio)
        {
            try
            {
                var nuevo = await _context.TblMunicipios.FindAsync(CodigoMunicipio);
                if (nuevo == null)
                    return NotFound(new { mensaje = $"El municipio {CodigoMunicipio} no existe" });
                nuevo.Nombre = municipio.Nombre ?? nuevo.Nombre;

                await _context.SaveChangesAsync();
                return Ok(new { mensaje = "Municipio actualizado correctamente" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guardar", error = ex.Message });
            }
        }

        [HttpDelete("Eliminar Municipio")]

        public async Task<ActionResult> MtdEliminarMunicipio(int CodigoMunicipio)
        {
            try
            {
                var municipio = await _context.TblMunicipios.FindAsync(CodigoMunicipio);
                if (municipio == null)
                    return NotFound(new { mensaje = $"El municipio {CodigoMunicipio} no existe" });
                _context.TblMunicipios.Remove(municipio);
                await _context.SaveChangesAsync();

                return Ok(new { mensaje = $"Municipio {CodigoMunicipio} eliminado con exito" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al eliminar", error = ex.Message });                
            }
        }

        [HttpGet("BuscarMunicipio")]

        public async Task<ActionResult<TblMunicipio>> MtdBuscarMunicipio(int CodigoMunicipio)
        {
            var municipio = await _context.TblMunicipios.FindAsync(CodigoMunicipio);
            if (municipio == null)
            {
                return NotFound(new { mensaje = $"El municipio {CodigoMunicipio} no existe" });
            }

            return (municipio);
        }
    }

}
