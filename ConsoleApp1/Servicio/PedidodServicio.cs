using App.Aplicaciones.Interfaces;
using App.Dominio;
using App.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Aplicaciones.Servicio
{
	public class PedidodServicio : IServicioMovimiento<Pedido, Guid>
	{
		private readonly IRepositorioBase<Articulo, Guid> repositorioArticulo;
		private readonly IRepositorioMovimiento<Pedido, Guid> repositorioPedido;
		private readonly IRepositorioDetalle<DetallePedidos, Guid> repositorioDetallePedido;

		public PedidodServicio(

			 IRepositorioMovimiento<Pedido, Guid> _repositorioPedido,
			IRepositorioBase<Articulo, Guid> _repositorioArticulo,
			IRepositorioDetalle<DetallePedidos, Guid> _repositorioDetallePedido

				)
		{
		
			repositorioPedido = _repositorioPedido;
			repositorioArticulo = _repositorioArticulo;
			repositorioDetallePedido = _repositorioDetallePedido;

		}

		public Pedido Agregar(Pedido entidad)
		{
			var FacturaAgregada = repositorioPedido.Agregar(entidad);

			entidad.DetallePedidoss.ForEach(pedido =>
			{
				pedido.PedidoID = entidad.PedidoID;
				var pedidoAgregada = repositorioPedido.Agregar(entidad);
				pedido.PedidoID.ForEach(detalle =>
				{
					var articuloSeleccionado = repositorioArticulo.SeleccionarPorID(detalle.ArticuloID);
					if (articuloSeleccionado == null)
						throw new NullReferenceException("Usted está intentando vender un Articulo que no existe 😡😡😡...");
					detalle.PedidoID = pedido.PedidoID;

					detalle.ArticuloID = articuloSeleccionado.ArticuloID;
					detalle.MontoT = articuloSeleccionado.Precio * detalle.Cantidad;
					detalle.MontoF = detalle.MontoT * detalle.Descuento / 100;
					articuloSeleccionado.Stock -= detalle.Cantidad;
					pedido.Total += detalle.MontoF;
					repositorioArticulo.Editar(articuloSeleccionado);
					repositorioDetallePedido.Agregar(detalle);
				});
				repositorioPedido.Agregar(entidad);
				entidad.Total += pedido.MontoT;
			});

			repositorioPedido.GuardarTodosLosCambios();
			return FacturaAgregada;
		}

		public void Anular(Guid ventaId)
		{
			repositorioPedido.Anular(ventaId);
			repositorioPedido.GuardarTodosLosCambios();
		}

		public List<Pedido> Listar()
		{
			return repositorioPedido.Listar();
		}

		public Pedido SeleccionarPorID(Guid ventaId)
		{
			return repositorioPedido.SeleccionarPorID(ventaId);
		}
	}
}
