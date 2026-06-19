using System;
using System.Collections.Generic;

namespace WebApiHotel;

public partial class TblCuotasPrestamo
{
    public int CodigoCuota { get; set; }

    public int? CodigoPrestamo { get; set; }

    public int? NumeroCuota { get; set; }

    public decimal? MontoCuota { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public DateTime? FechaPago { get; set; }

    public string? Estado { get; set; }

    public virtual TblPrestamo? CodigoPrestamoNavigation { get; set; }
}
