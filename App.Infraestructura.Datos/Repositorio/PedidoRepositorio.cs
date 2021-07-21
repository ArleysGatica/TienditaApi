using App.Dominio;
using App.Dominio.Interfaces.Repositorio;
using System;
using System.Linq;
using System.Collections.Generic;
using App.Infraestructura.Datos.Contexto;

namespace App.Infraestructura.Datos.Repositorio
{
   public class PedidoRepositorio : IRepositorioMovimiento<Pedido, Guid>
    {
		private AppDbContext db;

		public PedidoRepositorio(AppDbContext _db)
		{
			db = _db;
		}

		public Pedido Agregar(Pedido pedido)
		{
			pedido.PedidoID = Guid.NewGuid();

			db.pedidos.Add(pedido);

			return pedido;
		}

		public List<Pedido> Listar()
		{
			return db.pedidos.ToList();
		}

		public Pedido SeleccionarPorID(Guid entidadId)
		{
			var PedidoSeleccionado = db.pedidos.Where(c => c.PedidoID == entidadId).FirstOrDefault();
			return PedidoSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}

		public void Anular(Guid entidadId)
		{
			var ventaSeleccionada = SeleccionarPorID(entidadId);

			if (ventaSeleccionada != null)
			{
				ventaSeleccionada.anulado = true;

				db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
			else
			{
				throw new NullReferenceException("No se ha encontrado la venta que intenta anular... 😣");
			}
		}
	}
}
