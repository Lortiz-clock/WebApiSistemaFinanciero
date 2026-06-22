using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblTiposCuentum
{
    public int CodigoTipoCuenta { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<TblCuenta> TblCuenta { get; set; } = new List<TblCuenta>();
}
