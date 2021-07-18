using App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Infraestructura.Datos.Entidades
{

	class DetallePedidoConfig : IEntityTypeConfiguration<DetallePedidos>
	{
		public void Configure(EntityTypeBuilder<DetallePedidos> builder)
		{
			builder.ToTable("DetallePedido");

			builder.HasKey(detalle => new { detalle.ArticuloID, detalle.PedidoID });
			//Mrs. GREEN APPLE - インフェルノ（Inferno）
			builder
				.HasOne(detalle => detalle.Articulo)
				.WithMany(ped => ped.DetallePedidoss);

			builder
				.HasOne(detalle => detalle.Pedido)
				.WithMany(venta => venta.DetallePedidoss);
		}
	}
}