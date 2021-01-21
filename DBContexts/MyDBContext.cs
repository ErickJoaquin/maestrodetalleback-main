using MaestroDetalle.Models;  
using Microsoft.EntityFrameworkCore;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace MaestroDetalle.DBContexts  
{  
    public class MyDBContext : DbContext  
    {  
        public DbSet<Cliente> Clientes { get; set; }  
        public DbSet<Producto> Productos { get; set; }  
        public DbSet<Orden> Ordenes { get; set; }  
        public DbSet<OrdenDetalle> OrdenDetalles { get; set; }  

  
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)  
        {   
        }  
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            // Use Fluent API to configure  
  
            // Map entities to tables  
            modelBuilder.Entity<Cliente>().ToTable("Clientes");  
            modelBuilder.Entity<Producto>().ToTable("Productos");  
            modelBuilder.Entity<Orden>().ToTable("Ordenes");
            modelBuilder.Entity<OrdenDetalle>().ToTable("OrdenDetalles");  
  

  
            // Configure Primary Keys  
            modelBuilder.Entity<Cliente>().HasKey(cl => cl.Id).HasName("PK_Cliente");  
            modelBuilder.Entity<Producto>().HasKey(pr => pr.Id).HasName("PK_Producto");  
            modelBuilder.Entity<Orden>().HasKey(or => or.Id).HasName("PK_Orden");  
            modelBuilder.Entity<OrdenDetalle>().HasKey(od => od.Id).HasName("PK_OrdenDetalle");  


  
            // Configure columns  
            modelBuilder.Entity<Cliente>().Property(cl => cl.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();  
            modelBuilder.Entity<Cliente>().Property(cl => cl.Nombre).HasColumnType("nvarchar(100)").IsRequired();  

            modelBuilder.Entity<Producto>().Property(pr => pr.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();  
            modelBuilder.Entity<Producto>().Property(pr => pr.descripcion).HasColumnType("nvarchar(100)").IsRequired();  
            modelBuilder.Entity<Producto>().Property(pr => pr.precioUnidad).HasColumnType("int32").IsRequired();  
            modelBuilder.Entity<Producto>().Property(pr => pr.existencia).HasColumnType("int32").IsRequired();  

            modelBuilder.Entity<Orden>().Property(or => or.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();  
            modelBuilder.Entity<Orden>().Property(or => or.fechaCreacion).HasColumnType("DateTime").IsRequired();  
            modelBuilder.Entity<Orden>().Property(or => or.clientId).HasColumnType("int").IsRequired();  
            modelBuilder.Entity<Orden>().Property(or => or.total).HasColumnType("int").IsRequired();  

            modelBuilder.Entity<OrdenDetalle>().Property(od => od.productoId).HasColumnType("int").IsRequired();  
            modelBuilder.Entity<OrdenDetalle>().Property(od => od.cantidad).HasColumnType("int").IsRequired();  
            modelBuilder.Entity<OrdenDetalle>().Property(od => od.precio).HasColumnType("int").IsRequired();  
            modelBuilder.Entity<OrdenDetalle>().Property(od => od.ordenId).HasColumnType("int").IsRequired();  
  
            // Configure relationships  
            modelBuilder.Entity<Orden>().HasOne(or => or.Cliente).WithMany(cl => cl.Ordens).HasForeignKey(or => or.clientId).HasConstraintName("FK_ordens_clients");  
            modelBuilder.Entity<Cliente>().HasMany(cl => cl.Ordens).WithOne(or => or.Cliente).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_clients_ordens");  
            modelBuilder.Entity<Orden>().HasMany(or => or.OrdenDetalles).WithOne(od => od.Orden).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_ordens_detalles");  
            modelBuilder.Entity<OrdenDetalle>().HasOne(od => od.Orden).WithMany(or => or.OrdenDetalles).HasForeignKey(od => od.ordenId).HasConstraintName("FK_detalles_ordens");  
            modelBuilder.Entity<OrdenDetalle>().HasOne(od => od.Producto).WithMany(pr => pr.ordenDetalles).HasForeignKey(od => od.productoId).HasConstraintName("FK_detalles_productos");  
            modelBuilder.Entity<Producto>().HasMany(pr => pr.ordenDetalles).WithOne(od => od.Producto).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_productos_detalles");  

        }  
    }  
}  