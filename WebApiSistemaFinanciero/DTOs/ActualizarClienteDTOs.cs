namespace WebApiSistemaFinanciero.DTOs
{
    public class ActualizarClienteDTOs
    {
        public int? CodigoMunicipio { get; set; }

        public string? Nombre { get; set; }

        public string? Dpi { get; set; }

        public string? Nit { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public string? Direccion { get; set; }

        public string? Tipo { get; set; } = null;
    }
}
