using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.inlock.CodeFirst.Domains;
using Webapi.inlock.CodeFirst.Interfaces;

namespace Webapi.inlock.CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return Ok(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult GetByEmailAndPassword(string Email, string Senha)
        {
            try
            {
                Usuario usuarioAchado = _usuarioRepository.BuscarUsuario(Email, Senha);

                if (usuarioAchado != null)
                {
                    return Ok(usuarioAchado);
                }

                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
