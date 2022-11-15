using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    
    [ApiController]
    public class VentaController : ControllerBase
    {
        ADO_Venta _venta;
        public VentaController()
        {
            _venta = new ADO_Venta();
        }

        [Route("api/Ventas")]
        [HttpGet]
        public ActionResult Ventas(int idUsuario)
        {
            var result = _venta.Ventas(idUsuario);
            return Ok(result);
        }

        [Route("api/TraerProductosVenta")]
        [HttpGet]
        public ActionResult TraerProductosVenta()
        {
            var result = _venta.TraerProductosVenta();
            return Ok(result);
        }

        [Route("api/CargarVenta")]
        [HttpPost]
        public ActionResult CargarVenta(int id, List<ProductoVendido> productoVendidos)
        {
            _venta.CargarVenta(id, productoVendidos);
            string mensaje = "Venta cargada con exito!";
            return Ok(mensaje);
        }

        [Route("api/EliminarVenta")]
        [HttpDelete]
        public ActionResult EliminarVenta(int id)
        {
            _venta.EliminarVenta(id);
            string mensaje = "Venta eliminada con exito!";
            return Ok(mensaje);
        }


    }
}
