using App.Aplicaciones.Servicio;
using App.Dominio;
using App.Infraestructura.Datos.Contexto;
using App.Infraestructura.Datos.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infraestructura.Api.Controllers
{
    public class ProveedorController : Controller
    {
        public ProveedorServicio CrearServicio()
        {
            AppDbContext db = new AppDbContext();
            ProveedorRepositorio repositorio = new ProveedorRepositorio(db);
            ProveedorServicio servicio = new ProveedorServicio(repositorio);

            return servicio;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Proveedor>> Get()
        {
            ProveedorServicio servicio = CrearServicio();

            return Ok(servicio.Listar());

        }

        [HttpGet("{id}")]
        public ActionResult<Proveedor> Get(Guid id)
        {
            ProveedorServicio servicio = CrearServicio();

            return Ok(servicio.SeleccionarPorID(id));
        }
        // POST: ArticuloController/Create
        [HttpPost]
        public ActionResult<Proveedor> Post([FromBody] Proveedor Entidad)
        {
            ProveedorServicio servicio = CrearServicio();

            var resultado = servicio.Agregar(Entidad);

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Proveedor Entidad)
        {
            ProveedorServicio servicio = CrearServicio();

            Entidad.ProveedorID = id;

            servicio.Editar(Entidad);

            return Ok("Editado exitosamente");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ProveedorServicio servicio = CrearServicio();

            servicio.Eliminar(id);

            return Ok("Eliminado exitosamente");
        }
    }
}

