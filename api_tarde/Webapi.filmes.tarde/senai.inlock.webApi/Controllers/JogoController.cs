
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class JogoController : ControllerBase

    {
        private IJogoRepository _jogoRepository { get; set; }
         
        public JogoController()
        { 
            _jogoRepository = new JogoRepository();
        }


        /// <summary>
        /// endpoint de cadastrar jogos
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);
                return Created("objeto criado", novoJogo);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> ListaJogos = _jogoRepository.ListarTodos();

                return Ok(ListaJogos);

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
                _jogoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
               return BadRequest(erro.Message);
            }
        }
        
        
    }
}
