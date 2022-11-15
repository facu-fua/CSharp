using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    
    [ApiController]
    public class ProductoController : ControllerBase
    {
        ADO_Producto _producto;
        public ProductoController()
        {
            _producto = new ADO_Producto();
        }

        [Route("api/TraerProducto")]
        [HttpGet]
        public ActionResult TraerProducto(int idUsuario)
        {
            var result = _producto.TraerProducto(idUsuario);
            return Ok(result);
        }

        [Route("api/CrearProducto")]
        [HttpPost]
        public ActionResult CrearProducto(string descripciones, float costo, float precioVenta, int stock, int idUsuario)
        {
            _producto.CrearProducto(descripciones, costo, precioVenta, stock, idUsuario);
            var mensaje = "Producto creado con exito!";
            return Ok(mensaje);
        }

        [Route("api/ModificarProducto")]
        [HttpPut]
        public ActionResult ModificarProducto(int id, string descripciones, float costo, float precioVenta, int stock, int idUsuario)
        {
            _producto.ModificarProducto(id, descripciones, costo, precioVenta, stock, idUsuario);
            var mensaje = "Producto modificado con exito!";
            return Ok(mensaje);
        }

        [Route("api/EliminarProducto")]
        [HttpDelete]
        public ActionResult EliminarProducto(int id)
        {
            _producto.EliminarProducto(id);
            var mensaje = "Producto eliminado con exito!";
            return Ok(mensaje);
        }
    }
}
