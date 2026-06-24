using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSistemaFinanciero.DTOs;

namespace WebApiSistemaFinanciero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        //inyeccion del context
        private readonly DbAlianzaRegionalContext _context;

        //constructor para el context
        public ClientesController(DbAlianzaRegionalContext context)
        {
            _context = context;
        }

        //Metodo para listas los datos

        [HttpGet("Lista Clientes")]
        public async Task<ActionResult<IEnumerable<TblCliente>>> ListarClientes()
        {
            var Cliente = await _context.TblClientes.Select(c => new ClientesDTOs
            {
                CodigoCliente = c.CodigoCliente,
                CodigoMunicipio = c.CodigoMunicipio,
                Nombre = c.Nombre,
                Dpi = c.Dpi,
                Nit = c.Nit,
                Telefono = c.Telefono,
                Correo = c.Correo,
                Direccion = c.Direccion,
                Tipo = c.Tipo
            })
                .ToListAsync();
            return Ok(Cliente);
        }

        //Metodo para guardar un registro, se agrega la palabra bodi para solo colocar los datos dentro de corchetes
        [HttpPost("Guardar Cliente")]

        public async Task<ActionResult> GuardarCliente([FromBody] ClientesCrearDTOs Cliente)
        {
            try
            {
                var NuevoCliente = new TblCliente
                {                    
                    CodigoMunicipio = Cliente.CodigoMunicipio,
                    Nombre = Cliente.Nombre,
                    Dpi = Cliente.Dpi,
                    Nit = Cliente.Nit,
                    Telefono = Cliente.Telefono,
                    Correo = Cliente.Correo,
                    Direccion = Cliente.Direccion,
                    Tipo = Cliente.Tipo
                };

                _context.TblClientes.Add(NuevoCliente);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new {mensaje = "Cliente guardado correctamente", data = NuevoCliente});
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guardar el cliente", error = ex.Message });
            }
            
        }

        // Metodo para actualizar un registro

        [HttpPut("Actualizar Cliente")]
        
        public async Task<ActionResult> ActualizarCliente(int CodigoCliente, [FromBody] ActualizarClienteDTOs Cliente)
        {
            //validacion de existencia del cliente
            try
            {
                var ClienteA = await _context.TblClientes.FindAsync(CodigoCliente);
                if (ClienteA == null)
                
                    return NotFound(new {mensaje = $"El cliente {CodigoCliente} no existe"});
                //para no enviar todos los datos se puede agregar doble signo de interrogacion
                //para que si el dato esta vaccio deje el actual
                ClienteA.CodigoMunicipio    = Cliente.CodigoMunicipio   ?? ClienteA.CodigoMunicipio;
                ClienteA.Nombre             = Cliente.Nombre            ?? ClienteA.Nombre;
                ClienteA.Dpi                = Cliente.Dpi               ?? ClienteA.Dpi;
                ClienteA.Nit                = Cliente.Nit               ?? ClienteA.Nit;
                ClienteA.Telefono           = Cliente.Telefono          ?? ClienteA.Telefono;
                ClienteA.Correo             = Cliente.Correo            ?? ClienteA.Correo;
                ClienteA.Direccion          = Cliente.Direccion         ?? ClienteA.Direccion;
                ClienteA.Tipo               = Cliente.Tipo              ?? ClienteA.Tipo;

                await _context.SaveChangesAsync();
                return Ok(new {mensaje = "Cliente actualizado correctamente"});
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new {mensaje= "Error al actualizar", error = ex.Message });
            }
                 
                               
        }

        //Metodo para eliminar

        [HttpDelete("Eliminar Clientes")]

        public async Task<ActionResult> EliminarCliente(int CodigoCliente)
        {

            try
            {
                var cliente = await _context.TblClientes.FindAsync(CodigoCliente);
                if (cliente == null)
                return NotFound(new {mensaje = $"El cliente {CodigoCliente} no existe" });

                _context.TblClientes.Remove(cliente);
                await _context.SaveChangesAsync();

                return Ok(new {mensaje = $"Cliente {CodigoCliente} eliminado correctamente"});
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al eliminar", error = ex.Message });
            }
                   
                 
           
            
        }

        [HttpGet("Buscar Cliente")]

        public async Task<ActionResult<TblCliente>> BuscarCliente(int CodigoCliente)
        {
            var cliente = await _context.TblClientes.FindAsync(CodigoCliente);
            if (cliente == null)
            {
                return NotFound($"El cliente {CodigoCliente} no existe");
            }

            return (cliente);
        }
    }
}
