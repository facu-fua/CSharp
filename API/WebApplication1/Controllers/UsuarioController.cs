using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        ADO_Usuario _usuario;
        public UsuarioController()
        {
            _usuario = new ADO_Usuario();
        }

        [HttpGet]
        public ActionResult TraerUsuario(string NombreUsuario)
        {
            var result = _usuario.TraerUsuario(NombreUsuario);
            return Ok(result);
        }
    }
}
