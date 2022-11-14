using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        ADO_Producto _producto;
        public ProductoController()
        {
            _producto = new ADO_Producto();
        }

        [HttpGet]
        public ActionResult TraerProducto(int idUsuario)
        {
            var result = _producto.TraerProducto(idUsuario);
            return Ok(result);
        }

        [HttpPost]
        public void CrearProducto(string descripciones, float costo, float precioVenta, int stock, int idUsuario)
        {
            _producto.CrearProducto(descripciones, costo, precioVenta, stock, idUsuario);
        }

        [HttpPut]
        public void ModificarProducto(int id, string descripciones, float costo, float precioVenta, int stock, int idUsuario)
        {
            _producto.ModificarProducto(id, descripciones, costo, precioVenta, stock, idUsuario);
        }

        [HttpDelete]
        public void EliminarProducto(int id)
        {
            _producto.EliminarProducto(id);
        }
    }
}
