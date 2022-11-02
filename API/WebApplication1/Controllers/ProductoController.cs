﻿using Microsoft.AspNetCore.Http;
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
        public void CrearProducto(Producto product)
        {
            _producto.CrearProducto(product);
        }

        [HttpPut]
        public void ModificarProducto(Producto product)
        {
            _producto.ModificarProducto(product);
        }

        [HttpDelete]
        public void EliminarProducto(int id)
        {
            _producto.EliminarProducto(id);
        }
    }
}
