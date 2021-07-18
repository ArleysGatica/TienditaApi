using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Dominio
{
    public class Proveedor
    {
        [Key]
        public Guid ProveedorID { get; set; }
        public string Nombres { get; set; }
        public int Telefono { get; set; }
        public string SitioWeb { get; set; }
        public List<Articulo> articulos { get; set; }
    }
}
        