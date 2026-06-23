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

       

       
    }
}
