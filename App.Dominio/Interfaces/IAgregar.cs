using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dominio.Interfaces.Repositorio
{
	public interface IAgregar<TEntidad>
	{
		TEntidad Agregar(TEntidad entidad);
	}
}
