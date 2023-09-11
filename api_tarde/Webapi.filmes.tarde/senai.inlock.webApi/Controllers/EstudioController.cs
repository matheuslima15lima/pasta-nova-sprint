using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository= new EstudioRepository();
        }


        /// <summary>
        /// EndPoint de listar Estudios
        /// </summary>
        /// <returns>Lista De estudios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> ListaEstudios = _estudioRepository.ListarTodos();

                return Ok(ListaEstudios);
            }
            catch (Exception erro)
            {

              return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// EndPoint de cadastrar estudios
        /// </summary>
        /// <param name="novoEstudio">Estudio a ser cadastrado</param>
        /// <returns> mensagem de objeto criado</returns>
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try
            {
                _estudioRepository.Cadastrar(novoEstudio);

                return Created("Objeto Criado", novoEstudio);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
        [HttpDelete("{id}")]
        
        public IActionResult Delete(int id) 
        {
            try
            {
                _estudioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        
        }


    }
}
