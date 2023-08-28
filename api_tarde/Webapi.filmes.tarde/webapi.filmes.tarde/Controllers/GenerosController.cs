using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisicao sera no seguinte formato
    /// dominio/api/nomeController
    /// exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]


    ///Define que é um controlador de API
    [ApiController]

    /// DEFINE QUE O TIPO DE RESPOSTA DA API É JSON
    [Produces("application/json")]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instäncia do objeto _generoRepository para que haja referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método de listar os gêneros
        /// </summary>
        /// <returns>Lista de gêneros e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {


                // essa lista na frente significa que a lista que foi criada aqui será igual a lista
                // do genero repository

                //Cria uma lista para receber os generos
                //   |
                //   |
                //   |
                //  \/
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //retorna o status code 200 ok e a lista de generos no formato JSON
                return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //retorna um status code 400 - BadRequest e a mensagem de erro 
                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// endpoint que acessa o metodo de cadastrar genero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisicao</param>
        /// <returns>status code</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                //faz a chamada para o metodo cadastrado
                _generoRepository.Cadastrar(novoGenero);

                //retorna um status code
                return Created("objeto criado", novoGenero);


            }
            catch (Exception erro)
            {
                //retorna um status code 400 - BadRequest e a mensagem de erro 
                return BadRequest(erro.Message);
            }
        }

        //tem que expecificar que vai passar um id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                //return Ok(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }
        /// <summary>
        /// endpoint que busca por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);
               

                if (generoBuscado == null)
                {
                    return NotFound("id não encontrado!!!");
                }
                return StatusCode(200, generoBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
