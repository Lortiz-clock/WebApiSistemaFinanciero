using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblDepartamento
{
    public int CodigoDepartamento { get; set; }

    public int? CodigoRegion { get; set; }

    public string? Nombre { get; set; }

    public virtual TblRegion? CodigoRegionNavigation { get; set; }

    public virtual ICollection<TblMunicipio> TblMunicipios { get; set; } = new List<TblMunicipio>();
}
