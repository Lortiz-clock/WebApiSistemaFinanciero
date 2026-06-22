using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblRole
{
    public int CodigoRol { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<TblUsuario> TblUsuarios { get; set; } = new List<TblUsuario>();
}
