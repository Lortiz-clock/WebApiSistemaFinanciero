using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiHotel.DTOs; //DTO para no traer todos los datos que da por defecto la migracion

namespace WebApiHotel.Controllers
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

        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<TblEmpleado>>> ListarEmpleado()
        {
            var Empleados = await _context.TblEmpleados.ToListAsync();
            return Ok(Empleados);
        }

        //Metodo para guardar un nuevo registro

        [HttpPost("Guardar")]
        //El FromBody es para no colocarlo en el app 
        public async Task<ActionResult<TblEmpleado>> GuardarEmpleado([FromBody]TblEmpleado Empleado)
        {
            Empleado.FechaEntrada = DateTime.Now;
            _context.TblEmpleados.Add(Empleado);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, Empleado);
        }

        //Metodo para actualizar un registro

        [HttpPut("Actualizar/{CodigoEmpleado}")]
        public async Task<ActionResult> ActualizarEmpleado(int CodigoEmpleado, TblEmpleado Empleado)
        {
            //validar primero si el usuario existe
            var EmpleadoActualizado = await _context.TblEmpleados.FindAsync(CodigoEmpleado);
            if (EmpleadoActualizado == null)
            {
                return NotFound();
            }
            EmpleadoActualizado.CodigoSucursal = Empleado.CodigoSucursal;
            EmpleadoActualizado.Nombre = Empleado.Nombre;
            EmpleadoActualizado.Telefono = Empleado.Telefono;
            EmpleadoActualizado.Direccion = Empleado.Direccion;
            EmpleadoActualizado.Cargo = Empleado.Cargo;
            EmpleadoActualizado.Estado = Empleado.Estado;

            await _context.SaveChangesAsync();
            return Ok(EmpleadoActualizado);
        }

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
