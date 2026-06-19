using System;
using System.Collections.Generic;

namespace WebApiHotel;

public partial class TblRegion
{
    public int CodigoRegion { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<TblDepartamento> TblDepartamentos { get; set; } = new List<TblDepartamento>();
}
