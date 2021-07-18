using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dominio.Interfaces.Repositorio
{
	public interface IEliminar<TEntidadID>
	{
		void Eliminar(TEntidadID entidadId);
	}
}
