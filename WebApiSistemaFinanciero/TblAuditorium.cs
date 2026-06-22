using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblAuditorium
{
    public int CodigoAuditoria { get; set; }

    public int? CodigoUsuario { get; set; }

    public string? TablaAfectada { get; set; }

    public string? TipoOperacion { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? DatosAnteriores { get; set; }

    public string? DatosNuevos { get; set; }

    public virtual TblUsuario? CodigoUsuarioNavigation { get; set; }
}
