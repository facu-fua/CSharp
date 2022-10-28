using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        ADO_Venta _venta;
        public VentaController()
        {
            _venta = new ADO_Venta();
        }

        [HttpGet]
        public ActionResult Ventas(int idUsuario)
        {
            var result = _venta.Ventas(idUsuario);
            return Ok(result);
        }
    }
}
