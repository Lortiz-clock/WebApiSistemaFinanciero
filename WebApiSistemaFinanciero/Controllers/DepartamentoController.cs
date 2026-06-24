using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSistemaFinanciero.DTOs;

namespace WebApiSistemaFinanciero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private DbAlianzaRegionalContext _context;
        
        public DepartamentoController(DbAlianzaRegionalContext controler)
        {
            _context = controler;
        }

        [HttpGet("Listar Departamentos")]

        public async Task<ActionResult<IEnumerable<TblDepartamento>>> MtdListar()
        {
            var departamento = await _context.TblDepartamentos.Select(c => new DepartamentoDTOs
            {
                CodigoDepartamento = c.CodigoDepartamento,
                CodigoRegion = c.CodigoRegion,
                Nombre = c.Nombre
            })
                .ToListAsync();
            return Ok(departamento);
        }

        [HttpPost("Guardar Departamento")]

        public async Task<ActionResult> MtdGuardar([FromBody] DepartamentoDTOs departamento)
        {
            try
            {
                var nuevo = new TblDepartamento
                {
                    CodigoRegion = departamento.CodigoRegion,
                    Nombre = departamento.Nombre
                };

                _context.TblDepartamentos.Add(nuevo);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Departamento guardado con exito", data = nuevo });

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guardar", error = ex.Message });
            }
        }

        [HttpPut("Actualizar Departamento")]

        public async Task<ActionResult> MtdActualizarDepartamento(int CodigoDepartamento, [FromBody] DepartamentoDTOs departamento)
        {
            try
            {
                var nuevo = await _context.TblDepartamentos.FindAsync(CodigoDepartamento);
                if (nuevo == null)

                    return NotFound(new { mensaje = $"El departamento {CodigoDepartamento} no existe" });
                nuevo.CodigoRegion = departamento.CodigoRegion ?? nuevo.CodigoRegion;
                nuevo.Nombre = departamento.Nombre ?? nuevo.Nombre;

                await _context.SaveChangesAsync();
                return Ok(new { mensaje = "Departamento actualizado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al actualizar", error = ex.Message });                
            }
        }

        [HttpDelete("Eliminar Departamento")]

        public async Task<ActionResult> MtdElimninar(int CodigoDepartamento)
        {
            try
            {
                var departamento = await _context.TblDepartamentos.FindAsync(CodigoDepartamento);
                if (departamento == null)
                    return NotFound(new { mensaje = $"El departamento {CodigoDepartamento} no existe" });
                _context.Remove(departamento);
                await _context.SaveChangesAsync();

                return Ok(new { mensaje = $"Departamento {CodigoDepartamento} eliminado!!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al eliminar", error = ex.Message });                
            }
        }

        [HttpGet("Buscar Departamento")]

        public async Task<ActionResult<TblDepartamento>> MtdBuscar(int CodigoDepartamento)
        {
            var departamento = await _context.TblDepartamentos.FindAsync(CodigoDepartamento);
            if (departamento == null)
            {
                return NotFound(new { mensaje = $"El departamento {CodigoDepartamento} no existe" });
            }

            return (departamento);
        }

    }
}
