﻿// <auto-generated />
using System;
using MaestroDetalle.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace maestrodetalle.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("MaestroDetalle.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_Cliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MaestroDetalle.Models.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("DateTime");

                    b.Property<int>("total")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Orden");

                    b.HasIndex("clientId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("MaestroDetalle.Models.OrdenDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ordenId")
                        .HasColumnType("int");

                    b.Property<int>("precio")
                        .HasColumnType("int");

                    b.Property<int>("productoId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_OrdenDetalle");

                    b.HasIndex("ordenId");

                    b.ToTable("OrdenDetalles");
                });

            modelBuilder.Entity("MaestroDetalle.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("existencia")
                        .HasColumnType("int");

                    b.Property<int>("precioUnidad")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Producto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("MaestroDetalle.Models.Orden", b =>
                {
                    b.HasOne("MaestroDetalle.Models.Cliente", "Cliente")
                        .WithMany("Ordens")
                        .HasForeignKey("clientId")
                        .HasConstraintName("FK_clients_ordens")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MaestroDetalle.Models.OrdenDetalle", b =>
                {
                    b.HasOne("MaestroDetalle.Models.Orden", "Orden")
                        .WithMany("OrdenDetalles")
                        .HasForeignKey("ordenId")
                        .HasConstraintName("FK_detalles_ordens")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MaestroDetalle.Models.Producto", "Producto")
                        .WithMany("ordenDetalles")
                        .HasForeignKey("ordenId")
                        .HasConstraintName("FK_productos_detalles")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Orden");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("MaestroDetalle.Models.Cliente", b =>
                {
                    b.Navigation("Ordens");
                });

            modelBuilder.Entity("MaestroDetalle.Models.Orden", b =>
                {
                    b.Navigation("OrdenDetalles");
                });

            modelBuilder.Entity("MaestroDetalle.Models.Producto", b =>
                {
                    b.Navigation("ordenDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}