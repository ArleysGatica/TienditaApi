using System;
using System.Collections.Generic;
using System.Text;

using App.Dominio.Interfaces;
using App.Dominio.Interfaces.Repositorio;

namespace App.Aplicaciones.Interfaces
{
	public interface IServicioMovimiento<TEntidad, TEntidadID> : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>
	{
		void Anular(TEntidadID entidadId);
	}
}
