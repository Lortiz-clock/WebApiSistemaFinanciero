namespace WebApiHotel.DTOs
{
    public class EmpleadoDTO
    {
        public int? CodigoSucursal { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Cargo { get; set; }
    }
}
