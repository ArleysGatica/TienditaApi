using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Dominio
{
    public class Pedido
    {

        public Guid PedidoID { get; set; }

        public DateTime Fecha { get; set; }
        public Guid ClienteID { get; set; }
        public Cliente clienteN { get; set; }


        public bool anulado;

        public decimal Total {get; set;}

        public List<DetallePedidos> DetallePedidoss { get; set; }
    }
}
