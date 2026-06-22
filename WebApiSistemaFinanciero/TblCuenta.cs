using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblCuenta
{
    public int CodigoCuenta { get; set; }

    public int? CodigoCliente { get; set; }

    public int? CodigoMoneda { get; set; }

    public int? CodigoTipoCuenta { get; set; }

    public string? NumeroCuenta { get; set; }

    public decimal? Saldo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? Estado { get; set; }

    public virtual TblMoneda? CodigoMonedaNavigation { get; set; }

    public virtual TblTiposCuentum? CodigoTipoCuentaNavigation { get; set; }

    public virtual ICollection<TblTarjeta> TblTarjeta { get; set; } = new List<TblTarjeta>();

    public virtual ICollection<TblTransaccione> TblTransaccioneCodigoCuentaDestinoNavigations { get; set; } = new List<TblTransaccione>();

    public virtual ICollection<TblTransaccione> TblTransaccioneCodigoCuentaOrigenNavigations { get; set; } = new List<TblTransaccione>();
}
