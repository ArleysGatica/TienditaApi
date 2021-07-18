using System;
using System.Collections.Generic;
using System.Text;


namespace App.Dominio.Interfaces.Repositorio
{
	public interface IRepositorioDetalle<TEntidad, TMovimientoID>
	: IAgregar<TEntidad>, ITransaccion
	{

		List<TEntidad> SeleccionarDetallesPorMovimiento(TMovimientoID movimientoId);

	}
}


