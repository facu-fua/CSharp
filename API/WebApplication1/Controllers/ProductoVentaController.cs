using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    
    [ApiController]
    public class ProductoVentaController : ControllerBase
    {
        ADO_ProductoVenta _ProductoVenta;
        public ProductoVentaController()
        {
            _ProductoVenta = new ADO_ProductoVenta();
        }

        [Route("api/TraerProductoVendido")]
        [HttpGet]
        public ActionResult TraerProductoVendido(int id)
        {
            var result = _ProductoVenta.TraerProductoVendido(id);
            return Ok(result);
        }

        [Route("api/TraerProductosVendidos")]
        [HttpGet]
        public ActionResult TraerProductosVendidos()
        {
            var result = _ProductoVenta.TraerProductosVendidos();
            return Ok(result);
        }

    }

}
