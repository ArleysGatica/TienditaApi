using App.Dominio;
using App.Dominio.Interfaces.Repositorio;
using App.Infraestructura.Datos.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Infraestructura.Datos.Repositorio
{
   public class ProveedorRepositorio : IRepositorioBase<Proveedor, Guid>
	{
		private AppDbContext db;

		public ProveedorRepositorio(AppDbContext _db)
		{
			db = _db;
		}

		public Proveedor Agregar(Proveedor proveedor )
		{
			proveedor.ProveedorID = Guid.NewGuid();

			db.Proveedores.Add(proveedor);

			return proveedor;
		}

		public List<Proveedor> Listar()
		{
			return db.Proveedores.ToList();
		}

		public void Editar(Proveedor proveedor)
		{
			var ProveedorSeleccionado = db.Proveedores.Where(c => c.ProveedorID == proveedor.ProveedorID).FirstOrDefault();
			if (ProveedorSeleccionado != null)
			{
				ProveedorSeleccionado.Nombres = proveedor.Nombres;
				ProveedorSeleccionado.SitioWeb = proveedor.SitioWeb;

				db.Entry(ProveedorSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId)
		{
			var ProveedorSeleccionado = db.Proveedores.Where(c => c.ProveedorID == entidadId).FirstOrDefault();
			if (ProveedorSeleccionado != null)
			{
				db.Proveedores.Remove(ProveedorSeleccionado);
			}
		}

		public Proveedor SeleccionarPorID(Guid entidadId)
		{
			var ProveedorSeleccionado = db.Proveedores.Where(c => c.ProveedorID == entidadId).FirstOrDefault();
			return ProveedorSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}
    }
}
