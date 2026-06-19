using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiHotel;

public partial class DbAlianzaRegionalContext : DbContext
{
    public DbAlianzaRegionalContext()
    {
    }

    public DbAlianzaRegionalContext(DbContextOptions<DbAlianzaRegionalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAuditorium> TblAuditoria { get; set; }

    public virtual DbSet<TblCliente> TblClientes { get; set; }

    public virtual DbSet<TblCuenta> TblCuentas { get; set; }

    public virtual DbSet<TblCuotasPrestamo> TblCuotasPrestamos { get; set; }

    public virtual DbSet<TblDepartamento> TblDepartamentos { get; set; }

    public virtual DbSet<TblEmpleado> TblEmpleados { get; set; }

    public virtual DbSet<TblMoneda> TblMonedas { get; set; }

    public virtual DbSet<TblMunicipio> TblMunicipios { get; set; }

    public virtual DbSet<TblPlanilla> TblPlanillas { get; set; }

    public virtual DbSet<TblPrestamo> TblPrestamos { get; set; }

    public virtual DbSet<TblRegion> TblRegions { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblSucursale> TblSucursales { get; set; }

    public virtual DbSet<TblTarjeta> TblTarjetas { get; set; }

    public virtual DbSet<TblTiposCuentum> TblTiposCuenta { get; set; }

    public virtual DbSet<TblTiposTransaccione> TblTiposTransacciones { get; set; }

    public virtual DbSet<TblTransaccione> TblTransacciones { get; set; }

    public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<TblAuditorium>(entity =>
        {
            entity.HasKey(e => e.CodigoAuditoria).HasName("PK__tbl_Audi__C7B67BEAA392D769");

            entity.ToTable("tbl_Auditoria");

            entity.Property(e => e.DatosAnteriores)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DatosNuevos)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.TablaAfectada)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoOperacion)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.TblAuditoria)
                .HasForeignKey(d => d.CodigoUsuario)
                .HasConstraintName("FK__tbl_Audit__Codig__7D439ABD");
        });

        modelBuilder.Entity<TblCliente>(entity =>
        {
            entity.HasKey(e => e.CodigoCliente).HasName("PK__tbl_Clie__E0DD7E71B144EB2E");

            entity.ToTable("tbl_Clientes");

            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Dpi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DPI");
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NIT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoMunicipioNavigation).WithMany(p => p.TblClientes)
                .HasForeignKey(d => d.CodigoMunicipio)
                .HasConstraintName("FK__tbl_Clien__Codig__7E37BEF6");
        });

        modelBuilder.Entity<TblCuenta>(entity =>
        {
            entity.HasKey(e => e.CodigoCuenta).HasName("PK__tbl_Cuen__52DE7605403BF3F2");

            entity.ToTable("tbl_Cuentas");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.NumeroCuenta)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Saldo).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CodigoMonedaNavigation).WithMany(p => p.TblCuenta)
                .HasForeignKey(d => d.CodigoMoneda)
                .HasConstraintName("FK__tbl_Cuent__Codig__7F2BE32F");

            entity.HasOne(d => d.CodigoTipoCuentaNavigation).WithMany(p => p.TblCuenta)
                .HasForeignKey(d => d.CodigoTipoCuenta)
                .HasConstraintName("FK__tbl_Cuent__Codig__00200768");
        });

        modelBuilder.Entity<TblCuotasPrestamo>(entity =>
        {
            entity.HasKey(e => e.CodigoCuota).HasName("PK__tbl_Cuot__BE56107BB26E7642");

            entity.ToTable("tbl_CuotasPrestamo");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");
            entity.Property(e => e.MontoCuota).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CodigoPrestamoNavigation).WithMany(p => p.TblCuotasPrestamos)
                .HasForeignKey(d => d.CodigoPrestamo)
                .HasConstraintName("FK__tbl_Cuota__Codig__01142BA1");
        });

        modelBuilder.Entity<TblDepartamento>(entity =>
        {
            entity.HasKey(e => e.CodigoDepartamento).HasName("PK__tbl_Depa__FB463103D23A4F83");

            entity.ToTable("tbl_Departamento");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoRegionNavigation).WithMany(p => p.TblDepartamentos)
                .HasForeignKey(d => d.CodigoRegion)
                .HasConstraintName("FK__tbl_Depar__Codig__02084FDA");
        });

        modelBuilder.Entity<TblEmpleado>(entity =>
        {
            entity.HasKey(e => e.CodigoEmpleado).HasName("PK__tbl_Empl__324FED73522E2F0C");

            entity.ToTable("tbl_Empleados");

            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaEntrada).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoSucursalNavigation).WithMany(p => p.TblEmpleados)
                .HasForeignKey(d => d.CodigoSucursal)
                .HasConstraintName("FK__tbl_Emple__Codig__02FC7413");
        });

        modelBuilder.Entity<TblMoneda>(entity =>
        {
            entity.HasKey(e => e.CodigoMoneda).HasName("PK__tbl_Mone__8E6DB165D337FB82");

            entity.ToTable("tbl_Monedas");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Simbolo)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblMunicipio>(entity =>
        {
            entity.HasKey(e => e.CodigoMunicipio).HasName("PK__tbl_Muni__FC9CE6BF65D375BC");

            entity.ToTable("tbl_Municipio");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoDepartamentoNavigation).WithMany(p => p.TblMunicipios)
                .HasForeignKey(d => d.CodigoDepartamento)
                .HasConstraintName("FK__tbl_Munic__Codig__03F0984C");
        });

        modelBuilder.Entity<TblPlanilla>(entity =>
        {
            entity.HasKey(e => e.CodigoPlanilla).HasName("PK__tbl_Plan__A2CDA75AD8B0EA40");

            entity.ToTable("tbl_Planilla");

            entity.Property(e => e.Bonificacion).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descuentos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.Igss)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("IGSS");
            entity.Property(e => e.Isr)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ISR");
            entity.Property(e => e.Periodo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoMoneda)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoEmpleadoNavigation).WithMany(p => p.TblPlanillas)
                .HasForeignKey(d => d.CodigoEmpleado)
                .HasConstraintName("FK__tbl_Plani__Codig__04E4BC85");
        });

        modelBuilder.Entity<TblPrestamo>(entity =>
        {
            entity.HasKey(e => e.CodigoPrestamo).HasName("PK__tbl_Pres__9570E6BAB0874AF3");

            entity.ToTable("tbl_Prestamos");

            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.MontoOriginal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SaldoPendiente).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TasaInteres).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoPrestamo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoClienteNavigation).WithMany(p => p.TblPrestamos)
                .HasForeignKey(d => d.CodigoCliente)
                .HasConstraintName("FK__tbl_Prest__Codig__06CD04F7");

            entity.HasOne(d => d.CodigoMonedaNavigation).WithMany(p => p.TblPrestamos)
                .HasForeignKey(d => d.CodigoMoneda)
                .HasConstraintName("FK__tbl_Prest__Codig__05D8E0BE");
        });

        modelBuilder.Entity<TblRegion>(entity =>
        {
            entity.HasKey(e => e.CodigoRegion).HasName("PK__tbl_Regi__7F1F2F9AA89719E2");

            entity.ToTable("tbl_Region");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.CodigoRol).HasName("PK__tbl_Role__F0D1305745871263");

            entity.ToTable("tbl_Roles");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblSucursale>(entity =>
        {
            entity.HasKey(e => e.CodigoSucursal).HasName("PK__tbl_Sucu__E9A9A103C970E447");

            entity.ToTable("tbl_Sucursales");

            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoMunicipioNavigation).WithMany(p => p.TblSucursales)
                .HasForeignKey(d => d.CodigoMunicipio)
                .HasConstraintName("FK__tbl_Sucur__Codig__07C12930");
        });

        modelBuilder.Entity<TblTarjeta>(entity =>
        {
            entity.HasKey(e => e.CodigoTarjeta).HasName("PK__tbl_Targ__255AF784D7FB2A7F");

            entity.ToTable("tbl_Tarjetas");

            entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");
            entity.Property(e => e.LimiteCredito).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NumeroTarjeta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoClientesNavigation).WithMany(p => p.TblTarjeta)
                .HasForeignKey(d => d.CodigoClientes)
                .HasConstraintName("FK__tbl_Targe__Codig__09A971A2");

            entity.HasOne(d => d.CodigoCuentaNavigation).WithMany(p => p.TblTarjeta)
                .HasForeignKey(d => d.CodigoCuenta)
                .HasConstraintName("FK__tbl_Targe__Codig__08B54D69");
        });

        modelBuilder.Entity<TblTiposCuentum>(entity =>
        {
            entity.HasKey(e => e.CodigoTipoCuenta).HasName("PK__tbl_Tipo__0FE05A2513414CC3");

            entity.ToTable("tbl_TiposCuenta");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblTiposTransaccione>(entity =>
        {
            entity.HasKey(e => e.CodigoTipoTransaccion).HasName("PK__tbl_Tipo__B0FE651DF7041D00");

            entity.ToTable("tbl_TiposTransacciones");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblTransaccione>(entity =>
        {
            entity.HasKey(e => e.CodigoTransaccion).HasName("PK__tbl_Tran__A7EC8DDF06D7EC39");

            entity.ToTable("tbl_Transacciones");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaTransaccion).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CodigoCuentaDestinoNavigation).WithMany(p => p.TblTransaccioneCodigoCuentaDestinoNavigations)
                .HasForeignKey(d => d.CodigoCuentaDestino)
                .HasConstraintName("FK__tbl_Trans__Codig__0A9D95DB");

            entity.HasOne(d => d.CodigoCuentaOrigenNavigation).WithMany(p => p.TblTransaccioneCodigoCuentaOrigenNavigations)
                .HasForeignKey(d => d.CodigoCuentaOrigen)
                .HasConstraintName("FK__tbl_Trans__Codig__0C85DE4D");

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.TblTransacciones)
                .HasForeignKey(d => d.CodigoUsuario)
                .HasConstraintName("FK__tbl_Trans__Codig__0B91BA14");
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.CodigoUsuario).HasName("PK__tbl_Usua__F0C18F58F1577AA3");

            entity.ToTable("tbl_Usuarios");

            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoEmpleadoNavigation).WithMany(p => p.TblUsuarios)
                .HasForeignKey(d => d.CodigoEmpleado)
                .HasConstraintName("FK__tbl_Usuar__Codig__0E6E26BF");

            entity.HasOne(d => d.CodigoRolNavigation).WithMany(p => p.TblUsuarios)
                .HasForeignKey(d => d.CodigoRol)
                .HasConstraintName("FK__tbl_Usuar__Codig__0D7A0286");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
