using App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infraestructura.Datos.Entidades
{
	public class ProveedorEntidadConfig : IEntityTypeConfiguration<Proveedor>
	{
		public void Configure(EntityTypeBuilder<Proveedor> builder)
		{
			builder.ToTable("Proveedor");
			builder.HasKey(p => p.ProveedorID);

			// builder.HasKey(producto => producto.productoId);

			builder
			.HasMany(a => a.articulos)
			.WithOne(detalle => detalle.ProveedorN);
		}
	}
}
