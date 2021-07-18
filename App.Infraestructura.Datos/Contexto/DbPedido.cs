using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using App.Infraestructura.Datos.Helpers;
using App.Infraestructura.Datos.Entidades;
using App.Dominio.Interfaces.Repositorio;
using App.Dominio;

namespace App.Infraestructura.Datos.Contexto
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<DetallePedidos> DetallePedido { get; set; }
        public DbSet<Pedido> pedidos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
  
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(ConfiguracionGlobal.SqlServerConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DetallePedidoConfig());
            modelBuilder.ApplyConfiguration(new ProveedorEntidadConfig());
            modelBuilder.ApplyConfiguration(new CategoriaEntidadConfig());
            modelBuilder.ApplyConfiguration(new PedidoEntidadConfig());
            modelBuilder.ApplyConfiguration(new ClienteEntidadConfig());
            modelBuilder.ApplyConfiguration(new ArticuloEntidadConfig());

        }

    }
}
