using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Dominio;

namespace App.Infraestructura.Datos.Entidades
{
  	
	public class ArticuloEntidadConfig : IEntityTypeConfiguration<Articulo>
	{
		public void Configure(EntityTypeBuilder<Articulo> builder)
		{
			builder.ToTable ("Articulo");
			builder.HasKey(detalle =>  detalle.ArticuloID );

			// builder.HasKey(producto => producto.productoId);

			builder
				.HasMany(Articulo => Articulo.DetallePedidoss)
				.WithOne(detalle => detalle.Articulo);

		}

	}

}
