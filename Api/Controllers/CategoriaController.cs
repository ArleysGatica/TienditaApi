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
    public class CategoriaController : Controller
    {
        public CategoriaServicio CrearServicio()
        {
            AppDbContext db = new AppDbContext();
            CategoriaRepositorio repositorio = new CategoriaRepositorio(db);
            CategoriaServicio servicio = new CategoriaServicio(repositorio);

            return servicio;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            CategoriaServicio servicio = CrearServicio();

            return Ok(servicio.Listar());

        }

        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(Guid id)
        {
            CategoriaServicio servicio = CrearServicio();

            return Ok(servicio.SeleccionarPorID(id));
        }
        // POST: ArticuloController/Create
        [HttpPost]
        public ActionResult<Cliente> Post([FromBody] Categoria Entidad)
        {
            CategoriaServicio servicio = CrearServicio();

            var resultado = servicio.Agregar(Entidad);

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Categoria Entidad)
        {
           CategoriaServicio servicio = CrearServicio();

            Entidad.CategoriaID = id;

            servicio.Editar(Entidad);

            return Ok("Editado exitosamente");
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            CategoriaServicio servicio = CrearServicio();

            servicio.Eliminar(id);

            return Ok("Eliminado exitosamente");
        }
    }
}