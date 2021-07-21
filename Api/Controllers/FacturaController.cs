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
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : Controller
    {
        public PedidodetalleServicio CrearServicio()
        {
            AppDbContext db = new AppDbContext();
            DetallePedidoRepositorio repositorioFactura = new DetallePedidoRepositorio(db);
            ArticuloRepositorio repositorioArticulo = new ArticuloRepositorio(db);
            PedidoRepositorio repositorioPedido = new PedidoRepositorio(db);
            DetallePedidoRepositorio repositorioDetallePedido = new DetallePedidoRepositorio(db);
            PedidodetalleServicio servicio = new PedidodetalleServicio( repositorioPedido, repositorioArticulo,  repositorioDetallePedido);

            return servicio;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> Get()
        {
            PedidodetalleServicio servicio = CrearServicio();

            return Ok(servicio.Listar());

        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(Guid id)
        {
            PedidodetalleServicio servicio = CrearServicio();

            return Ok(servicio.SeleccionarPorID(id));
        }
        // POST: ArticuloController/Create
        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] Pedido Entidad)
        {
            PedidodetalleServicio servicio = CrearServicio();

            var resultado = servicio.Agregar(Entidad);

            return Ok(new Pedido()
            {

                ClienteID = resultado.ClienteID,
                Fecha = resultado.Fecha,
                Total = resultado. Total,
                PedidoID = resultado.PedidoID
            });
        }
    }
}
