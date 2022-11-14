using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        ADO_Usuario _usuario;
        public UsuarioController()
        {
            _usuario = new ADO_Usuario();
        }

        [Route("api/TraerUsuario")]
        [HttpGet]
        public ActionResult TraerUsuario(string NombreUsuario)
        {
            var result = _usuario.TraerUsuario(NombreUsuario);
            return Ok(result);
        }

        [Route("api/TraerNombre")]
        [HttpGet]
        public ActionResult TraerNombre(string user)
        {
            var result = _usuario.TraerNombre(user);
            return Ok(result);
        }

        [Route("api/CrearUsuario")]
        [HttpPost]
        public ActionResult CrearUsuario(string nombre, string apellido, string nombreUsuario, string password, string mail)
        {
            _usuario.CrearUsuario(nombre,apellido,nombreUsuario,password,mail);
            var mensaje = "Usuario creado con exito!";
            return Ok(mensaje);
        }

        [Route("api/ModificarUsuario")]
        [HttpPut]
        public ActionResult ModificarUsuario(Usuario user)
        {
            _usuario.ModificarUsuario(user);
            var mensaje = "Usuario modificado con exito!";
            return Ok(mensaje);
        }

        [Route("api/EliminarUsuario")]
        [HttpDelete]
        public ActionResult EliminarUsuario(string user)
        {
            _usuario.EliminarUsuario(user);
            var mensaje = "Usuario eliminado con exito!";
            return Ok(mensaje);
        }
    }
}
