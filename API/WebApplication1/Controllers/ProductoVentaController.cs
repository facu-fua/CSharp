using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVentaController : ControllerBase
    {
        ADO_ProductoVenta _ProductoVenta;
        public ProductoVentaController()
        {
            _ProductoVenta = new ADO_ProductoVenta();
        }

        [HttpGet]
        public ActionResult TraerProductoVendido(int id)
        {
            var result = _ProductoVenta.TraerProductoVendido(id);
            return Ok(result);
        }

    }
}
