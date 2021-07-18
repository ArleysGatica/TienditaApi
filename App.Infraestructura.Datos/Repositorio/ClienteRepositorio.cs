using App.Dominio;
using App.Dominio.Interfaces.Repositorio;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using App.Infraestructura.Datos.Contexto;

namespace App.Infraestructura.Datos.Repositorio
{
   public class ClienteRepositorio : IRepositorioBase<Cliente, Guid>
    {

		private AppDbContext db;

		public ClienteRepositorio(AppDbContext _db)
		{
			db = _db;
		}

		public Cliente Agregar(Cliente cliente)
		{
			cliente.ClienteID = Guid.NewGuid();

			db.clientes.Add(cliente);

			return cliente;
		}

		public List<Cliente> Listar()
		{
			return db.clientes.ToList();
		}

		public void Editar(Cliente cliente)
		{
			var ClienteSeleccionado = db.clientes.Where(c => c.ClienteID == cliente.ClienteID).FirstOrDefault();
			if (ClienteSeleccionado != null)
			{
				ClienteSeleccionado.NombresCl = cliente.NombresCl;
				ClienteSeleccionado.Cedula = cliente.Cedula;
				ClienteSeleccionado.ApellidosCl = cliente.ApellidosCl;
				ClienteSeleccionado.Direccion = cliente.Direccion;
				ClienteSeleccionado.Telefono = cliente.Telefono;
				ClienteSeleccionado.Sexo = cliente.Sexo;

				db.Entry(ClienteSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId)
		{
			var ClienteSeleccionado = db.clientes.Where(c => c.ClienteID == entidadId).FirstOrDefault();
			if (ClienteSeleccionado != null)
			{
				db.clientes.Remove(ClienteSeleccionado);
			}
		}

		public Cliente SeleccionarPorID(Guid entidadId)
		{
			var ClienteSeleccionado = db.clientes.Where(c => c.ClienteID == entidadId).FirstOrDefault();
			return ClienteSeleccionado;
		}

		public void GuardarTodosLosCambios()
		{
			db.SaveChanges();
		}

       
    }
}
