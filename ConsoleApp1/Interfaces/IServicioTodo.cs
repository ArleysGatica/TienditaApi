using App.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Aplicaciones.Interfaces
{
    class IServicioTodo
    {
        public interface IServicioNombre<TEntidad, TEntidadID, TEntidadNombre>
         : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ITransaccion
        { }
    }
}
