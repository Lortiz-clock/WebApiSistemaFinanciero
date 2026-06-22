using System;
using System.Collections.Generic;

namespace WebApiSistemaFinanciero;

public partial class TblPlanilla
{
    public int CodigoPlanilla { get; set; }

    public int? CodigoEmpleado { get; set; }

    public decimal? Salario { get; set; }

    public decimal? Bonificacion { get; set; }

    public decimal? Isr { get; set; }

    public decimal? Igss { get; set; }

    public decimal? Descuentos { get; set; }

    public DateTime? FechaPago { get; set; }

    public string? Periodo { get; set; }

    public string? TipoMoneda { get; set; }

    public virtual TblEmpleado? CodigoEmpleadoNavigation { get; set; }
}
