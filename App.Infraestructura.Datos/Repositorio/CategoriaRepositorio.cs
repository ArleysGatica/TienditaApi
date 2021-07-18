using App.Dominio;
using App.Dominio.Interfaces.Repositorio;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using App.Infraestructura.Datos.Contexto;

namespace App.Infraestructura.Datos.Repositorio
{
	public class CategoriaRepositorio : IRepositorioBase<Categoria, Guid>
	{
		private AppDbContext db;

		public CategoriaRepositorio(AppDbContext _db)
		{
			db = _db;
		}

		public Categoria Agregar(Categoria categoria)
		{
			categoria.CategoriaID = Guid.NewGuid();

			db.Categoria.Add (categoria);

			return categoria;
		}

		public List<Categoria> Listar()
		{
			return db.Categoria.ToList();
		}

		public void Editar(Categoria categoria)
		{
			var CategoriaSeleccionado = db.Categoria.Where(c => c.CategoriaID == categoria.CategoriaID).FirstOrDefault();
			if (CategoriaSeleccionado != null)
			{
				CategoriaSeleccionado.Descripcion = categoria.Descripcion;
				CategoriaSeleccionado.Nombre = categoria.Nombre;
				
				db.Entry(CategoriaSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId)
		{
			var CategoriaSeleccionado = db.Categoria.Where(c => c.CategoriaID == entidadId).FirstOrDefault();
			if (CategoriaSeleccionado != null)
			{
				db.Categoria.Remove(CategoriaSeleccionado);
			}
		}

		public Categoria SeleccionarPorID(Guid entidadId)
		{
			var CategoriaSeleccionado = db.Categoria.Where(c => c.CategoriaID == entidadId).FirstOrDefault();
			return CategoriaSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}
    }
}
