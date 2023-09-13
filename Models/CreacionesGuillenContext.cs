using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Models;

public partial class CreacionesGuillenContext : DbContext
{
    public CreacionesGuillenContext()
    {
    }

    public CreacionesGuillenContext(DbContextOptions<CreacionesGuillenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tamaño> Tamaños { get; set; }

    public virtual DbSet<Trabajador> Trabajadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=creaciones_guillen;Trusted_Connection=True;TrustServerCertificate=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__clientes__3DD0A8CB64007CB2");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.Dirección).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(15)
                .HasColumnName("Numero_Telefono");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__detalle___B3E0CED3D4335701");

            entity.ToTable("detalle_pedidos");

            entity.Property(e => e.IdDetalle).HasColumnName("ID_Detalle");
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.IdEncargado).HasColumnName("ID_Encargado");
            entity.Property(e => e.IdPedido).HasColumnName("ID_Pedido");
            entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

            entity.HasOne(d => d.IdEncargadoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdEncargado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_pedidos_trabajadores");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_pedidos_pedidos");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_pedidos_productos");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__pedidos__A5D00139ADFFED19");

            entity.ToTable("pedidos");

            entity.Property(e => e.IdPedido).HasColumnName("Id_Pedido");
            entity.Property(e => e.FechaPedido)
                .HasColumnType("date")
                .HasColumnName("Fecha_Pedido");
            entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedidos_clientes");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__2085A9CF462D0DDA");

            entity.ToTable("productos");

            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.IdTamaño).HasColumnName("ID_tamaño");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__roles__55932E86DBFBA6BD");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        modelBuilder.Entity<Tamaño>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tamaños");

            entity.Property(e => e.IdTamaño)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_tamaño");
            entity.Property(e => e.NombreTamaño)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Nombre_tamaño");
        });

        modelBuilder.Entity<Trabajador>(entity => 
        {
            entity.HasKey(e => e.IdTrabajador).HasName("PK__trabajad__D3644B9543FB50C5");

            entity.ToTable("trabajadores");

            entity.Property(e => e.IdTrabajador).HasColumnName("Id_Trabajador");
            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Dirección).HasMaxLength(100);
            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(15)
                .HasColumnName("Numero_Telefono");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Trabajadores)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_trabajadores_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
