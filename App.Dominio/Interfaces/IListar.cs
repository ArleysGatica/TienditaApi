using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dominio.Interfaces.Repositorio
{
	public interface IListar<TEntidad, TEntidadID>
	{
		List<TEntidad> Listar();

		TEntidad SeleccionarPorID(TEntidadID entidadId);
	}
}

