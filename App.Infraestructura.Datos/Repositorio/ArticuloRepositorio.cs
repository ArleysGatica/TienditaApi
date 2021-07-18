using App.Dominio;
using App.Dominio.Interfaces.Repositorio;
using App.Infraestructura.Datos.Contexto;
using System;
using System.Collections.Generic;

using System.Linq;

namespace App.Infraestructura.Datos.Repositorio
{
   public class ArticuloRepositorio : IRepositorioBase<Articulo, Guid>
    {

		private AppDbContext db;

		public ArticuloRepositorio(AppDbContext _db)
		{
			db = _db;
		}

		public Articulo Agregar(Articulo articulo)
		{
			articulo.ArticuloID = Guid.NewGuid();

			db.Articulo.Add(articulo);

			return articulo;
		}

		public List<Articulo> Listar()
		{
			return db.Articulo.ToList();
		}

		public void Editar(Articulo articulo)
		{
			var articuloSeleccionado = db.Articulo.Where(c => c.ArticuloID == articulo.ArticuloID).FirstOrDefault();
			if (articuloSeleccionado != null)
			{
				articuloSeleccionado.NombreArt = articulo.NombreArt;
				articuloSeleccionado.Precio = articulo.Precio;
				articuloSeleccionado.Stock = articulo.Stock;
				articuloSeleccionado.Imagen = articulo.Imagen;

				db.Entry(articuloSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId)
		{
			var articuloSeleccionado = db.Articulo.Where(c => c.ArticuloID == entidadId).FirstOrDefault();
			if (articuloSeleccionado != null)
			{
				db.Articulo.Remove(articuloSeleccionado);
			}
		}

		public Articulo SeleccionarPorID(Guid entidadId)
		{
			var articuloSeleccionado = db.Articulo.Where(c => c.ArticuloID == entidadId).FirstOrDefault();
			return articuloSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}

    }
}

