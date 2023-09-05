using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [Authorize (Roles = "Administrador")]//precisa estar logado para acessar a rota
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
        /// <summary>
        /// deletando usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        ///     atualiza por id passando id pelo corpo
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdCorpo(genero);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }


                }
                return NotFound("Genero não encontrado !");
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// atualiza pelo id passando pela url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id,GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdUrl(id, genero);
                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("gênero não encontrado !!!");
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
