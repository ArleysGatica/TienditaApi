using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Dominio;

namespace App.Infraestructura.Datos.Entidades
{  
		public class PedidoEntidadConfig : IEntityTypeConfiguration<Pedido>
		{
			public void Configure(EntityTypeBuilder<Pedido> builder)
			{
				builder.ToTable("Pedido");
			builder.HasKey(p => p.PedidoID);

			builder
					.HasMany(cli => cli.DetallePedidoss)
					.WithOne(pedido => pedido.Pedido);
			
		}
		}
	}

