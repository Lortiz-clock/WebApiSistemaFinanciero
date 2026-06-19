using System;
using System.Collections.Generic;

namespace WebApiHotel;

public partial class TblRole
{
    public int CodigoRol { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<TblUsuario> TblUsuarios { get; set; } = new List<TblUsuario>();
}
