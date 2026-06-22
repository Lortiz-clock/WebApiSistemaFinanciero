using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblMunicipio
{
    public int CodigoMunicipio { get; set; }

    public int? CodigoDepartamento { get; set; }

    public string? Nombre { get; set; }

    public virtual TblDepartamento? CodigoDepartamentoNavigation { get; set; }

    public virtual ICollection<TblCliente> TblClientes { get; set; } = new List<TblCliente>();

    public virtual ICollection<TblSucursale> TblSucursales { get; set; } = new List<TblSucursale>();
}
