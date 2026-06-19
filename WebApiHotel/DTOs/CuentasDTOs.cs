namespace WebApiHotel.DTOs
{
    public class CuentasDTOs
    {
        public int CodigoCuenta { get; set; }

        public int? CodigoCliente { get; set; }

        public int? CodigoMoneda { get; set; }

        public int? CodigoTipoCuenta { get; set; }

        public string? NumeroCuenta { get; set; }

        public decimal? Saldo { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public bool? Estado { get; set; }

    }
}
