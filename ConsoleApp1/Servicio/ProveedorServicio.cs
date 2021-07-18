using App.Aplicaciones.Interfaces;
using App.Dominio;
using App.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using static App.Aplicaciones.Interfaces.IServicioTodo;

namespace App.Aplicaciones.Servicio
{
	public class ProveedorServicio : IServicioBase<Proveedor, Guid>
	{

		private readonly IRepositorioBase<Proveedor, Guid> repositorio;

		public ProveedorServicio(IRepositorioBase<Proveedor, Guid> _repositorio)
		{
			repositorio = _repositorio;
		}

		public Proveedor Agregar(Proveedor entidad)
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

		public List<Proveedor> Listar()
		{
			return repositorio.Listar();
		}

		public void Editar(Proveedor entidad)
		{
			repositorio.Editar(entidad);
			repositorio.GuardarTodosLosCambios();
		}

		public void Eliminar(Guid entidadId)
		{
			repositorio.Eliminar(entidadId);
			repositorio.GuardarTodosLosCambios();
		}

		public Proveedor SeleccionarPorID(Guid entidadId)
		{
			return repositorio.SeleccionarPorID(entidadId);
		}

			public void GuardarTodosLosCambios()
		{
			repositorio.GuardarTodosLosCambios();
		}
	}
 }
