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
    public class FilmeController : ControllerBase
    {

        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }


        /// <summary>
        /// Instäncia do objeto _FilmeRepository para que haja referência aos métodos no repositório
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método de listar os filmes
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
                List<FilmeDomain> ListaFilmes = _filmeRepository.ListarTodos();

                //retorna o status code 200 ok e a lista de generos no formato JSON
                return Ok(ListaFilmes);
            }
            catch (Exception erro)
            {
                //retorna um status code 400 - BadRequest e a mensagem de erro 
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// endpoint que acessa o metodo de cadastrar filmes
        /// </summary>
        /// <param name="novoFilme">Objeto recebido na requisicao</param>
        /// <returns>status code</returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                //faz a chamada para o metodo cadastrado
                _filmeRepository.Cadastrar(novoFilme);

                //retorna um status code
                return Created("objeto criado", novoFilme);


            }
            catch (Exception erro)
            {
                //retorna um status code 400 - BadRequest e a mensagem de erro 
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Metodo de deletar Filmes
        /// </summary>
        /// <param name="id"> Acha o filme pelo id</param>
        /// <returns></returns>
        //tem que expecificar que vai passar um id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                //return Ok(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(Id);

                if (filmeBuscado == null)
                {
                    return NotFound("id não encontrado!!!");

                }
                return StatusCode(200, filmeBuscado);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut]
        public IActionResult PutIdBody(FilmeDomain filme) 
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filme.IdFilme);
                if(filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdCorpo(filme);
                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
