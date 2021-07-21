using App.Aplicaciones.Servicio;
using App.Dominio;
using App.Infraestructura.Datos.Contexto;
using App.Infraestructura.Datos.Repositorio;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infraestructura.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : Controller
    {
        public ArticuloServicio CrearServicio()
        {
            AppDbContext db = new AppDbContext();
            ArticuloRepositorio repositorio = new ArticuloRepositorio(db);
            ArticuloServicio servicio = new ArticuloServicio(repositorio);

            return servicio;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Articulo>> Get()
        {
            ArticuloServicio servicio = CrearServicio();

            return Ok(servicio.Listar());

        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{id}")]

        public ActionResult<Articulo> Get(Guid id)
        {
            ArticuloServicio servicio = CrearServicio();

            return Ok(servicio.SeleccionarPorID(id));
        }
        // POST: ArticuloController/Create
        [HttpPost]
        public ActionResult<Articulo> Post([FromBody] Articulo Entidad)
        {
            ArticuloServicio servicio = CrearServicio();

            var resultado = servicio.Agregar(Entidad);

            return Ok(resultado);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{id}")]
       
        public ActionResult Put(Guid id, [FromBody] Articulo Entidad)
        {
            ArticuloServicio servicio = CrearServicio();

            Entidad.ArticuloID = id;

            servicio.Editar(Entidad);

            return Ok("Editado exitosamente");
        }

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ArticuloServicio servicio = CrearServicio();

            servicio.Eliminar(id);

            return Ok("Eliminado exitosamente");
        }
    }
}
