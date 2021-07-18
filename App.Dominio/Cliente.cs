using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Dominio
{
    public class Cliente
    {
        [Key]

        public Guid ClienteID { get; set; }
        public string Cedula { get; set; }
        public string NombresCl { get; set; }
        public string ApellidosCl { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public char Sexo { get; set; }

        

        public List<Pedido> Pedidos { get; set; }

    }
}
