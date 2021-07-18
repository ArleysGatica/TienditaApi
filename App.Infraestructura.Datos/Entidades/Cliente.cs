using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Dominio;

namespace App.Infraestructura.Datos.Entidades
{
		public class ClienteEntidadConfig : IEntityTypeConfiguration<Cliente>
		{
			public void Configure(EntityTypeBuilder<Cliente> builder)
			{
				builder.ToTable("Cliente");
			builder.HasKey(Cliente => Cliente.ClienteID);
				      
					builder.HasMany(p => p.Pedidos)
					   .WithOne(c => c.clienteN);

		}
		}
	}

