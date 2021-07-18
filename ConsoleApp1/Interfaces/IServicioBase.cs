using System;
using System.Collections.Generic;
using System.Text;

using App.Dominio.Interfaces;
using App.Dominio.Interfaces.Repositorio;

namespace App.Aplicaciones.Interfaces
{

	public interface IServicioBase<TEntidad, TEntidadID>
		: IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
	{ }
}

