using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSistemaFinanciero.DTOs; //DTO para no traer todos los datos que da por defecto la migracion

namespace WebApiSistemaFinanciero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        //inyeccion de la clase generada con el comando Scaffold-DbContext se debe de aclarar que se usa:
        //Microsoft.EntityFrameworkCore.SqlServer
        private readonly DbAlianzaRegionalContext _context;
            
        //constructor
        public EmpleadoController(DbAlianzaRegionalContext context)
        {
            _context = context;
        }


        //Metodo para listar

        [HttpGet("Lista Empleados")]
        public async Task<ActionResult<IEnumerable<TblEmpleado>>> ListarEmpleado()
        {
            var Empleados = await _context.TblEmpleados.Select(c => new EmpleadoDTO
            {
                CodigoSucursal = c.CodigoSucursal,
                Nombre = c.Nombre,
                Telefono = c.Telefono,
                FechaEntrada = c.FechaEntrada,
                Direccion = c.Direccion,
                FechaNacimiento = c.FechaNacimiento,
                Cargo = c.Cargo
            })
                .ToListAsync();
            return Ok(Empleados);
            
            
        }

        //Metodo para guardar un nuevo registro

        [HttpPost("Guardar Empleado")]
        public async Task<ActionResult> GuardarEmpleado([FromBody] CrearEmpleadoDTOs empleado)
        {
            try
            {
                var NuevoEmpleado = new TblEmpleado
                {
                    CodigoSucursal = empleado.CodigoSucursal,
                    Nombre = empleado.Nombre,
                    Telefono = empleado.Telefono,
                    FechaEntrada = empleado.FechaEntrada,
                    Direccion = empleado.Direccion,
                    FechaNacimiento = empleado.FechaNacimiento,
                    Cargo = empleado.Cargo
                };
                _context.TblEmpleados.Add(NuevoEmpleado);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Empleado guardado correctamente", data = NuevoEmpleado });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mnesaje = "Error al guardar el empleado", error = ex.Message });

            }
        }

        //Metodo para actualizar un registro

      

        //Metodo para elimiar un registro

        [HttpDelete("EliminarEmpleado")]
        public async Task<ActionResult>ElimininarEmpleado(int CodigoEmpleado)
        {
            var Empleado = await _context.TblEmpleados.FindAsync(CodigoEmpleado);
            if (Empleado == null)
            {
                return NotFound($"El empleado: {CodigoEmpleado} no existe, error al eliminar");
            }
            _context.TblEmpleados.Remove(Empleado);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Metodo para buscar un registro apartir de su codigo
           
        [HttpGet("Buscar Empleado")]
        public async Task<ActionResult<TblEmpleado>> BuscarEmpleado(int CodigoEmpleado)
        {
            var Empleado = await _context.TblEmpleados.FindAsync(CodigoEmpleado);
            if (Empleado == null)
            {
                return NotFound($"El empleado: {CodigoEmpleado} no existe");
            }
            return Ok(Empleado);
        }
    }
}
