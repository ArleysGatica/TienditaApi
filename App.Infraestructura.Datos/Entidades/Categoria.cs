using App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infraestructura.Datos.Entidades
{
    class CategoriaEntidadConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(Categoria => Categoria.CategoriaID);

            builder
                .HasMany(arti => arti.Articulos)
                .WithOne(detalle => detalle.CategoriaN);

        }
    }
}