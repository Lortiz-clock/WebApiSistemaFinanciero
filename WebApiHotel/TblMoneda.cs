using System;
using System.Collections.Generic;

namespace WebApiHotel;

public partial class TblMoneda
{
    public int CodigoMoneda { get; set; }

    public string? Nombre { get; set; }

    public string? Simbolo { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<TblCuenta> TblCuenta { get; set; } = new List<TblCuenta>();

    public virtual ICollection<TblPrestamo> TblPrestamos { get; set; } = new List<TblPrestamo>();
}
