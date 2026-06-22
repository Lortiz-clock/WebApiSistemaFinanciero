namespace WebApiHotel.DTOs
{
    public class EditarEmpleado
    {
        public int? CodigoSucursal { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
       
        public string? Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Cargo { get; set; }
    }
}
