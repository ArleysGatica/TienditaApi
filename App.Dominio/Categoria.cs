using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dominio
{
    public class Categoria
    {
        public Guid CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Articulo> Articulos { get; set; }
    }
}
