using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;
using webapi.inlock.tarde.Repositories;

namespace webapi.inlock.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository;

        public EstudioController()
        { 
            _estudioRepository= new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
        
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarComJogos")]
        public IActionResult GetWithGames() 
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id) 
        {
            try
            {
                _estudioRepository.Deletar(Id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Estudio estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(Guid Id) 
        {
            try
            {
                return Ok(_estudioRepository.BuscarPorId(Id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        }

        [HttpPut("{Id}")]
        public IActionResult Put(Guid Id, Estudio estudio)
        {
            try
            {
                _estudioRepository.Atualizar(Id, estudio);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
