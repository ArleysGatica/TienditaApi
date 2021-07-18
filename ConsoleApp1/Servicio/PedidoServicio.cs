using App.Aplicaciones.Interfaces;
using App.Dominio;
using App.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Aplicaciones.Servicio
{
	public class PedidoServicio : IServicioBase<Pedido, Guid>
	{

		private readonly IRepositorioBase<Pedido, Guid> repositorio;

		public PedidoServicio(IRepositorioBase<Pedido, Guid> _repositorio)
		{
			repositorio = _repositorio;
		}

		public Pedido Agregar(Pedido entidad)
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

		public List<Pedido> Listar()
		{
			return repositorio.Listar();
		}

		public void Editar(Pedido entidad)
		{
			repositorio.Editar(entidad);
			repositorio.GuardarTodosLosCambios();
		}

		public void Eliminar(Guid entidadId)
		{
			repositorio.Eliminar(entidadId);
			repositorio.GuardarTodosLosCambios();
		}

		public Pedido SeleccionarPorID(Guid entidadId)
		{
			return repositorio.SeleccionarPorID(entidadId);
		}

		public void GuardarTodosLosCambios()
		{
			repositorio.GuardarTodosLosCambios();
		}

    }
}
