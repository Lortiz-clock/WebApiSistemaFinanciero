namespace WebApiSistemaFinanciero.DTOs
{
    public class PrestamoDTOs
    {
        public int CodigoPrestamo { get; set; }

        public int? CodigoMoneda { get; set; }

        public int? CodigoCliente { get; set; }

        public string? TipoPrestamo { get; set; }

        public decimal? MontoOriginal { get; set; }

        public decimal? SaldoPendiente { get; set; }

        public decimal? TasaInteres { get; set; }

        public int? Plazo { get; set; }

        public DateTime? FechaInicio { get; set; }

        public bool? Estado { get; set; }
    }
}
