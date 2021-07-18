using App.Dominio;
using App.Dominio.Interfaces.Repositorio;
using System;
using System.Linq;
using System.Collections.Generic;
using App.Infraestructura.Datos.Contexto;

namespace App.Infraestructura.Datos.Repositorio
{
    public class DetallePedidoRepositorio : IRepositorioDetalle<DetallePedidos, Guid>
    {
		private AppDbContext db;

		public DetallePedidoRepositorio(AppDbContext _db)
		{
			db = _db;
		}

        public DetallePedidos Agregar(DetallePedidos entidad)
        {

            db.DetallePedido.Add(entidad);

            return entidad;
        }


        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<DetallePedidos> SeleccionarDetallesPorMovimiento(Guid movimientoId)
        {
            return db.DetallePedido.Where(c => c.PedidoID == movimientoId).ToList();
        }
    }
}
