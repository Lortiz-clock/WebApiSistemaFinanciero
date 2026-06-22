using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblUsuario
{
    public int CodigoUsuario { get; set; }

    public int? CodigoEmpleado { get; set; }

    public int? CodigoRol { get; set; }

    public string? Nombre { get; set; }

    public string Clave { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual TblEmpleado? CodigoEmpleadoNavigation { get; set; }

    public virtual TblRole? CodigoRolNavigation { get; set; }

    public virtual ICollection<TblAuditorium> TblAuditoria { get; set; } = new List<TblAuditorium>();

    public virtual ICollection<TblTransaccione> TblTransacciones { get; set; } = new List<TblTransaccione>();
}
