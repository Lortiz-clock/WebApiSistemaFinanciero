using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblEmpleado
{
    public int CodigoEmpleado { get; set; }

    public int? CodigoSucursal { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaEntrada { get; set; }

    public string? Direccion { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Cargo { get; set; }

    public bool? Estado { get; set; }

    public virtual TblSucursale? CodigoSucursalNavigation { get; set; }

    public virtual ICollection<TblPlanilla> TblPlanillas { get; set; } = new List<TblPlanilla>();

    public virtual ICollection<TblUsuario> TblUsuarios { get; set; } = new List<TblUsuario>();
}
