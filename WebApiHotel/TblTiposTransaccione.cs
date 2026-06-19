using System;
using System.Collections.Generic;

namespace WebApiHotel;

public partial class TblTiposTransaccione
{
    public int CodigoTipoTransaccion { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }
}
