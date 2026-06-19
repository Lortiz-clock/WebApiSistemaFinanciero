using System;
using System.Collections.Generic;

namespace WebApiHotel;

public partial class TblSucursale
{
    public int CodigoSucursal { get; set; }

    public int? CodigoMunicipio { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public bool? Estado { get; set; }

    public virtual TblMunicipio? CodigoMunicipioNavigation { get; set; }

    public virtual ICollection<TblEmpleado> TblEmpleados { get; set; } = new List<TblEmpleado>();
}
