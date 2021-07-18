using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dominio.Interfaces.Repositorio
{
	public interface IEditar<TEntidad>
	{
		void Editar(TEntidad entidad);
	}
}
