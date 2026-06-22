using System.ComponentModel.DataAnnotations;

namespace WebApiSistemaFinanciero.DTOs
{
    public class ClientesCrearDTOs
    {
        public int? CodigoMunicipio { get; set; }
        [Required(ErrorMessage = "El Nombre Es obligatorio")]
        [StringLength(100, ErrorMessage ="El nombre no puede superar los 100 caracteres")]
        public string? Nombre { get; set; }

        [StringLength(13, MinimumLength = 13, ErrorMessage ="El DPI debe contener 13 caracteres")]
        public string? Dpi { get; set; }

        public string? Nit { get; set; }

        [RegularExpression(@"^[2-7]\d{7}$", ErrorMessage = "El teléfono debe tener 8 dígitos y empezar con 2-7")]
        public string? Telefono { get; set; }

        [EmailAddress(ErrorMessage ="El formato del correo no es valido")]
        public string? Correo { get; set; }

        public string? Direccion { get; set; }

        public string? Tipo { get; set; } = null;
    }
}
