using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Dominio
{
   
		public class Articulo
		{
			[Key]
			public Guid ArticuloID { get; set; }
			public Guid ProveedorID { get; set; }
			public Guid CategoriaID { get; set; }
			public string NombreArt { get; set; }
			public decimal Precio { get; set; }
			public int Stock { get; set; }
			public string Imagen { get; set; }
		    public  Categoria CategoriaN { get; set; }
			public Proveedor ProveedorN { get; set; }

			public List<DetallePedidos> DetallePedidoss { get; set; }
		}
}
