using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Dominio
{
   public class DetallePedidos
    {
        public bool anulado;

        [Key]
		public Guid ArticuloID { get; set; }
		public Guid PedidoID { get; set; }
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal Descuento { get; set; }
		public decimal MontoT { get; set; }
		public decimal MontoF { get; set; }
		public Pedido Pedido { get; set; }
		public Articulo Articulo { get; set; }
	}
}
