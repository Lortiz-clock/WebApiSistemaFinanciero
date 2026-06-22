using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblTransaccione
{
    public int CodigoTransaccion { get; set; }

    public int? CodigoCuentaOrigen { get; set; }

    public int? CodigoCuentaDestino { get; set; }

    public int? CodigoUsuario { get; set; }

    public int? CodigoTipoTransaccion { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? FechaTransaccion { get; set; }

    public string? Descripcion { get; set; }

    public virtual TblCuenta? CodigoCuentaDestinoNavigation { get; set; }

    public virtual TblCuenta? CodigoCuentaOrigenNavigation { get; set; }

    public virtual TblUsuario? CodigoUsuarioNavigation { get; set; }
}
