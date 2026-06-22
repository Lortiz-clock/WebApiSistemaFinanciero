using System.ComponentModel.DataAnnotations;

namespace WebApiHotel.DTOs
{
    public class CrearEmpleadoDTOs
    {
        [Required(ErrorMessage = "El numero de sucursal es obligatorio")]
        public int? CodigoSucursal { get; set; }
        [Required(ErrorMessage ="Colocar nombre de empleado")]
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        [RegularExpression(@"^[2-7]/s{7}$", ErrorMessage = "El numero debe contener 8 digitos")]
        public DateTime? FechaEntrada { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Cargo { get; set; }
    }
}
