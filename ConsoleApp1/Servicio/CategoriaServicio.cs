using App.Aplicaciones.Interfaces;
using App.Dominio;
using App.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Aplicaciones.Servicio
{

	public class CategoriaServicio : IServicioBase<Categoria, Guid>
	{

		private readonly IRepositorioBase<Categoria, Guid> repositorio;

		public CategoriaServicio(IRepositorioBase<Categoria, Guid> _repositorio)
		{
			repositorio = _repositorio;
		}

		public Categoria Agregar(Categoria entidad)
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

		public List<Categoria> Listar()
		{
			return repositorio.Listar();
		}

		public void Editar(Categoria entidad)
		{
			repositorio.Editar(entidad);
			repositorio.GuardarTodosLosCambios();
		}

		public void Eliminar(Guid entidadId)
		{
			repositorio.Eliminar(entidadId);
			repositorio.GuardarTodosLosCambios();
		}

		public Categoria SeleccionarPorID(Guid entidadId)
		{
			return repositorio.SeleccionarPorID(entidadId);
		}

		public void GuardarTodosLosCambios()
		{
			repositorio.GuardarTodosLosCambios();
		}
	}
}
