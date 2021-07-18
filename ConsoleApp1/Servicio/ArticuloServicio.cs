using App.Aplicaciones.Interfaces;
using App.Dominio;
using App.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Aplicaciones.Servicio
{
	public class ArticuloServicio : IServicioBase<Articulo, Guid>
	{

		private readonly IRepositorioBase<Articulo, Guid> repositorio;

		public ArticuloServicio(IRepositorioBase<Articulo, Guid> _repositorio)
		{
			repositorio = _repositorio;
		}

		public Articulo Agregar(Articulo entidad)
		{
			if (entidad != null)
			{
				var resultado = repositorio.Agregar(entidad);
				repositorio.GuardarTodosLosCambios();
				return resultado;
			}
			else
				throw new Exception("Error la entidad no puede ser nula");
		}

		public List<Articulo> Listar()
		{
			return repositorio.Listar();
		}

		public void Editar(Articulo entidad)
		{
			repositorio.Editar(entidad);
			repositorio.GuardarTodosLosCambios();
		}

		public void Eliminar(Guid entidadId)
		{
			repositorio.Eliminar(entidadId);
			repositorio.GuardarTodosLosCambios();
		}

		public Articulo SeleccionarPorID(Guid entidadId)
		{
			return repositorio.SeleccionarPorID(entidadId);
		}

		public void GuardarTodosLosCambios()
		{
			repositorio.GuardarTodosLosCambios();
		}
    }
}
