using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblPrestamo
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

    public virtual TblCliente? CodigoClienteNavigation { get; set; }

    public virtual TblMoneda? CodigoMonedaNavigation { get; set; }

    public virtual ICollection<TblCuotasPrestamo> TblCuotasPrestamos { get; set; } = new List<TblCuotasPrestamo>();
}
