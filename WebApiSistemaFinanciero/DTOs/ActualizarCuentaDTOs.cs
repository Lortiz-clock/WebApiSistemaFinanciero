namespace WebApiSistemaFinanciero.DTOs
{
    public class ActualizarCuentaDTOs
    {
        public int? CodigoMoneda { get; set; }

        public int? CodigoTipoCuenta { get; set; }

        public string? NumeroCuenta { get; set; }
        public decimal? Saldo { get; set; }
        public bool? Estado { get; set; }
    }
}
