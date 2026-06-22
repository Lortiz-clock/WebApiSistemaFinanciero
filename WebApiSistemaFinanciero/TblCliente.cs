using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblCliente
{
    public int CodigoCliente { get; set; }

    public int? CodigoMunicipio { get; set; }

    public string? Nombre { get; set; }

    public string? Dpi { get; set; }

    public string? Nit { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Tipo { get; set; }

    public virtual TblMunicipio? CodigoMunicipioNavigation { get; set; }

    public virtual ICollection<TblPrestamo> TblPrestamos { get; set; } = new List<TblPrestamo>();

    public virtual ICollection<TblTarjeta> TblTarjeta { get; set; } = new List<TblTarjeta>();
}
