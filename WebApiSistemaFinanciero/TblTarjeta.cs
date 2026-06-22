using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblTarjeta
{
    public int CodigoTarjeta { get; set; }

    public int? CodigoCuenta { get; set; }

    public int? CodigoClientes { get; set; }

    public string? NumeroTarjeta { get; set; }

    public string? Tipo { get; set; }

    public decimal? LimiteCredito { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public bool? Estado { get; set; }

    public virtual TblCliente? CodigoClientesNavigation { get; set; }

    public virtual TblCuenta? CodigoCuentaNavigation { get; set; }
}
